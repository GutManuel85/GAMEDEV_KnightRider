using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       transform.position =  GameObject.FindGameObjectWithTag("Player").transform.position;
        //Debug.Log("Position: " + transform.position.ToString());
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit() aufgerufen");
        if (other.tag == "Traffic" || other.tag == "Bullet" || other.tag == "Plane" || other.tag == "BulletShoot")
        {
            Destroy(other.gameObject);
            Debug.Log("Destroy Object");
        }
    }




}
