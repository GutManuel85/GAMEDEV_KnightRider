using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public AudioClip audio;
    public ParticleSystem ps;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BulletShoot(Clone)")
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);

            ParticleSystem a = Instantiate(ps, new Vector3(gameObject.transform.position.x, 1.5f, gameObject.transform.position.z), Quaternion.identity);
            a.Play();
            Destroy(gameObject);
        }
    }
}
