using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{

    private float xPositionTrack1 = -7f;
    private float xPositionTrack2 = -2f;
    private float xPositionTrack3 = 2f;
    private float xPositionTrack4 = 7f;
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
        try
        {
            if (rigidbodyList != null && rigidbodyList.Count != 0)
            {
                foreach (Rigidbody element in rigidbodyList)
                {
                    element.MovePosition(element.transform.position + new Vector3(0, 0, 1) * -getSpeed() * Time.deltaTime);
                }

            }
        }
        catch(MissingReferenceException e) {
            Debug.Log(e.StackTrace);
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

        int numberToSetTrafficOrNot = Random.Range(1, 3);

        if (numberToSetTrafficOrNot == 1)
        {
            if (trackNumber1 == 1)
            {
                this.InstantiateTrafficObject(trafficObject1, xPositionTrack1, zPosition1);
            }
            else
            {
                this.InstantiateTrafficObject(trafficObject1, xPositionTrack3, zPosition1);
            }
        }

        int trackNumber2 = Random.Range(3, 5);

        numberToSetTrafficOrNot = Random.Range(1, 3);

        if (numberToSetTrafficOrNot == 1)
        {

            if (trackNumber2 == 3)
            {
                this.InstantiateTrafficObject(trafficObject2, xPositionTrack2, zPosition2);
            }
            else
            {
                this.InstantiateTrafficObject(trafficObject2, xPositionTrack4, zPosition2);
            }
        }

    }

    private void InstantiateTrafficObject(GameObject trafficObject, float xPostion, float zPosition)
    {
        GameObject traffic1 = Instantiate(trafficObject, new Vector3(xPostion, 0f, zPosition1), new Quaternion(0, 0, 0, 0));
        if(trafficObject.name == "Car_evil")
        {
            traffic1.GetComponent<EnemyDestroy>().sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }
        rigidbodyList.Add(traffic1.GetComponent<Rigidbody>());
    }

    private int getSpeed()
    {
        return Mathf.RoundToInt((float)(20 + timeManager.getTime() * 0.5));
    }

}
