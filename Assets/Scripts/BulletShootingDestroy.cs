using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingDestroy : MonoBehaviour
{

    private void Update()
    {
        
     }

    private void OnTriggerEnter(Collider other)
    {
        print("xxx");
        if (other.gameObject.tag == "Traffic") Destroy(gameObject);
        if (other.gameObject.tag == "Traffic") Destroy(other.gameObject);
    }
}
