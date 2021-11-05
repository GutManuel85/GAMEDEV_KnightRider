using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    private int initAmount = 10;
    private float planeSize = 30f;
    private float xPositionLeft = -10f;
    private float xPositionRight = 10f;
    private float lastZPosition = 0f;

    public List<GameObject> planeList;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < initAmount; i++)
        {
            TransferPlane();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransferPlane()
    {
        GameObject planeLeft = planeList[Random.Range(0, planeList.Count)];
        GameObject planeRight = planeList[Random.Range(0, planeList.Count)];

        float zPosition = lastZPosition + planeSize;

        Instantiate(planeLeft, new Vector3(xPositionLeft, 0f, zPosition), planeLeft.transform.rotation);
        Instantiate(planeRight, new Vector3(xPositionRight, 0f, zPosition), new Quaternion(0, 180, 0, 0));

        lastZPosition += planeSize;
    }
}
