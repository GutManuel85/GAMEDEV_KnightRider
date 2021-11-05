using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private RoadController roadController;
    private PlaneManager planeManager;


    // Start is called before the first frame update
    void Start()
    {
        roadController = GetComponent<RoadController>();
        planeManager = GetComponent<PlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        roadController.TransferRoad();
        planeManager.TransferPlane();
    }
}
