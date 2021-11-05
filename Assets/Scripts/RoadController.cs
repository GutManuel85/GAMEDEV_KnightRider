using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadController : MonoBehaviour
{

    public List<GameObject> roadList;
    private float offset = 30f;

    // Start is called before the first frame update
    void Start()
    {
        if(roadList.Count > 0 && roadList == null)
        {
            roadList = roadList.OrderBy(element => element.transform.position.z).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 
    public void TransferRoad()
    {
        GameObject transferedRoad = roadList[0];
        float newPositionZ = roadList[roadList.Count - 1].transform.position.z + offset;
        transferedRoad.transform.position = new Vector3(0, 0, newPositionZ);
        roadList.Remove(transferedRoad);
        roadList.Add(transferedRoad);
    }
}
