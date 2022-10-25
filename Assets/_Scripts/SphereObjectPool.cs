using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObjectPool : MonoBehaviour
{
    public SphereControl spherePrefab;

    public Transform sphereSpawn;

    public List<Transform> sphereSpawners = new List<Transform>();

    public int spawnIndex = 0;

    private List<SphereControl> spheres = new List<SphereControl>();

    private const int InitPoolSize = 15;

    private const int MaxPoolSize = 30;

    private SphereControl firstAvailable;

    // Start is called before the first frame update
    void Start()
    {
        if (spherePrefab == null)
        {
            Debug.LogError("No prefab reference");
        }

        for (int i = 0; i < InitPoolSize; i++) 
        {
            GenerateSphere();
        }

        firstAvailable = spheres[0];

        for (int i = 0; i < spheres.Count - 1; i++)
        {
            spheres[i].nextSphere = spheres[i + 1];
        }

        spheres[spheres.Count - 1].nextSphere = null;
    }

    private void GenerateSphere() 
    {
        SphereControl newSphere = Instantiate(spherePrefab, sphereSpawners[spawnIndex]);

        newSphere.gameObject.SetActive(false);

        spheres.Add(newSphere);

        newSphere.objectPool = this;
    }

    public void ConfigureDeactivatedSphere(SphereControl deactivatedObj)
    {
        deactivatedObj.nextSphere = firstAvailable;

        firstAvailable = deactivatedObj;
    }

    public GameObject GetSphere() 
    {

        if (firstAvailable == null) 
        {
            if (spheres.Count < MaxPoolSize)
            {
                GenerateSphere();

                SphereControl lastSphere = spheres[spheres.Count - 1];
                ConfigureDeactivatedSphere(lastSphere);
            }
            else 
            {
                return null;
            }
        }

        SphereControl newSphere = firstAvailable;

        firstAvailable = newSphere.nextSphere;

        return newSphere.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject newSphere = GetSphere();

            if (newSphere != null)
            {
                newSphere.SetActive(true);

                newSphere.transform.position = sphereSpawners[spawnIndex].position;
                //newSphere.transform.forward = transform.forward;
            }
            else
            {
                Debug.Log("Couldn't find a new sphere");
            }
        }

        if (spawnIndex < sphereSpawners.Count - 1)
        {
            spawnIndex++;
        }
        else 
        {
            spawnIndex = 0;
        }
    }
}
