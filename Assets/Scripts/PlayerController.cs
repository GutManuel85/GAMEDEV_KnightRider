using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SpawnManager spawnManager;
    public TrafficSpawner trafficSpawner;
    public LifeManager lifeManager;
    public TimeManager timeManager;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Print: PlayerController.OnTriggerEnter()");

        if(other.tag == "Traffic")
        {
            print("Print: Reduce Life");
            lifeManager.reduceLife();
        }
        if (other.tag == "Road")
        {
            spawnManager.SpawnTriggerEntered();
            trafficSpawner.TransferTraffic();
        }
    }

    private void Move()
    {
        
        float hMovement = Input.GetAxis("Horizontal") / 2;
        float vMovement = 1;

        Vector3 move = transform.position + new Vector3(hMovement, 0, vMovement) * getSpeed() * Time.deltaTime;
        

        if (hMovement != 0)
        {
            vMovement = 0.7f;
        }

        //with this method (moveposition) the player goes through the walls (ignore the physics), for this reason we set manually the limits on x axis
        //if out of limits, move only forward
        if (move.x < 9 && move.x > -9) _rigidbody.MovePosition(move);
        else _rigidbody.MovePosition(transform.position + new Vector3(0, 0, vMovement) * getSpeed() * Time.deltaTime);

        
        //_rigidbody.MovePosition(transform.position + new Vector3(hMovement, 0, vMovement) * movementSpeed * Time.deltaTime);
        

    }

    public Rigidbody GetRigidbody()
    {
        return this._rigidbody;
    }

    private int getSpeed()
    {
        return Mathf.RoundToInt((float)(30 + timeManager.getTime()));
    }


}
