using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    public float sphereSpeed = 0.5f;
    private float deactivationDistance = 30f;

    [System.NonSerialized] public SphereControl nextSphere;
    [System.NonSerialized] public SphereObjectPool objectPool;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(transform.position) > deactivationDistance * deactivationDistance)
        {
            objectPool.ConfigureDeactivatedSphere(this);

            gameObject.SetActive(false);
        }
    }
}
