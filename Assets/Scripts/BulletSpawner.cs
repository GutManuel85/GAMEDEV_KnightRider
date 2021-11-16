using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    private float xPositionTrack1 = -7f;
    private float xPositionTrack2 = -2f;
    private float xPositionTrack3 = 2f;
    private float xPositionTrack4 = 7f;
    private float zPosition1;
    private float distance1;
    private List<Rigidbody> rigidbodyList;


    public TimeManager timeManager;
    public List<GameObject> trafficList;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyList = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (rigidbodyList != null && rigidbodyList.Count != 0)
        {
            foreach (Rigidbody element in rigidbodyList)
            {
                element.MovePosition(element.transform.position + new Vector3(0, 0, 1) * - getSpeed() * Time.deltaTime);
            }

        }
    }

    public void TransferBullet()
    {
        GameObject bulletObject1 = trafficList[Random.Range(0, trafficList.Count)];
        Debug.Log("BulletObject1: " + bulletObject1.name);

        distance1 = 200 + Random.Range(5, 10);
        zPosition1 = playerController.GetRigidbody().transform.position.z + distance1;
        Debug.Log("Distance 1 :" + distance1);


        int trackNumber = Random.Range(1, 5);

        int numberToSetBulletOrNot = Random.Range(1, 5);

        if (numberToSetBulletOrNot == 1)
        {
            if (trackNumber == 1)
            {
                this.InstantiateBulletObject(bulletObject1, xPositionTrack1, zPosition1);
            }
            else if (trackNumber == 2)
            {
                this.InstantiateBulletObject(bulletObject1, xPositionTrack2, zPosition1);
            }
            else if (trackNumber == 3)
            {
                this.InstantiateBulletObject(bulletObject1, xPositionTrack3, zPosition1);
            }
            else
            {
                this.InstantiateBulletObject(bulletObject1, xPositionTrack4, zPosition1);
            }
        }



    }

    private void InstantiateBulletObject(GameObject trafficObject, float xPostion, float zPosition)
    {
        GameObject bullet = Instantiate(trafficObject, new Vector3(xPostion, 0f, zPosition1), new Quaternion(0, 0, 0, 0));
        rigidbodyList.Add(bullet.GetComponent<Rigidbody>());
    }

    private int getSpeed()
    {
        return Mathf.RoundToInt((float)(10 + timeManager.getTime() * 0.5));
    }

}
