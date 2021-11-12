using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
 
    private float xPositionTrack1 = -9f;
    private float xPositionTrack2 = -2f;
    private float xPositionTrack3 = 3f;
    private float xPositionTrack4 = 9f;
    private float zPosition1;
    private float zPosition2;
    private float distance1;
    private float distance2;
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
            foreach(Rigidbody element in rigidbodyList)
            {
                element.MovePosition(element.transform.position + new Vector3(0, 0, 1) * - getSpeed() * Time.deltaTime);
            }

        }
    }

    public void TransferTraffic()
    {
        GameObject trafficObject1 = trafficList[Random.Range(0, trafficList.Count)];
        GameObject trafficObject2 = trafficList[Random.Range(0, trafficList.Count)];
        Debug.Log("TrafficObject1: " + trafficObject1.name);
        Debug.Log("TrafficObject2: " + trafficObject2.name);

        distance1 = 200 + Random.Range(5, 10);
        zPosition1 = playerController.GetRigidbody().transform.position.z + distance1;
        Debug.Log("Distance 1 :" + distance1);

        distance2 = 200 + Random.Range(15, 20);
        zPosition2 = playerController.GetRigidbody().transform.position.z + distance2;
        Debug.Log("Distance 2 :" + distance2);


        int trackNumber1 = Random.Range(1, 3);

        int numberToTrafficOrNot = Random.Range(1, 3);

        if (numberToTrafficOrNot == 1)
        {
            if (trackNumber1 == 1)
            {
                this.InstantiateTrafficObject(trafficObject1, xPositionTrack1);
            }
            else
            {
                this.InstantiateTrafficObject(trafficObject1, xPositionTrack3);
            }
        }

        int trackNumber2 = Random.Range(3, 5);

        numberToTrafficOrNot = Random.Range(1, 3);

        if (numberToTrafficOrNot == 1)
        {

            if (trackNumber2 == 3)
            {
                this.InstantiateTrafficObject(trafficObject2, xPositionTrack2);
            }
            else
            {
                this.InstantiateTrafficObject(trafficObject2, xPositionTrack4);
            }
        }

    }

private void InstantiateTrafficObject(GameObject trafficObject, float xPostion)
    {
        GameObject traffic1 = Instantiate(trafficObject, new Vector3(xPostion, 0f, zPosition1), new Quaternion(0, 0, 0, 0));
        GameObject traffic2 = Instantiate(trafficObject, new Vector3(xPostion, 0f, zPosition2), new Quaternion(0, 0, 0, 0));
        rigidbodyList.Add(traffic1.GetComponent<Rigidbody>());
        rigidbodyList.Add(traffic2.GetComponent<Rigidbody>());
    }

    private int getSpeed()
    {
        return Mathf.RoundToInt((float)(10 + timeManager.getTime() * 0.5));
    }

}
