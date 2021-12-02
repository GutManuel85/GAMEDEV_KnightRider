using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingDestroy : MonoBehaviour
{
    private void Update()
    {
        
        
        //Destroy(gameObject, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Car(Clone)") Destroy(gameObject);
        if (collision.gameObject.name == "Bus(Clone)") Destroy(gameObject);
        if (collision.gameObject.name == "Truck(Clone)") Destroy(gameObject);
    }
}
