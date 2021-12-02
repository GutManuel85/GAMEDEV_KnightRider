using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BulletShoot(Clone)") Destroy(gameObject);
    }
}
