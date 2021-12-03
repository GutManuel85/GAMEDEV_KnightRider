using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SpawnManager spawnManager;
    public TrafficSpawner trafficSpawner;
    public BulletSpawner bulletSpawner;
    public BulletManager bulletManager;
    public LifeManager lifeManager;
    public TimeManager timeManager;
    public CameraController cameraController;
    
    private Rigidbody _rigidbody;
    private bool _isInvulnerable;
    private int _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _isInvulnerable = false;
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
            if (!_isInvulnerable)
            {
                print("Shake Camera");
                cameraController.shakeCamera();
                print("Print: Reduce Life");
                lifeManager.reduceLife();
                StartCoroutine("SetInvulnerable");
            }
        }

        if (other.tag == "Bullet")
        {
            print("Print: Add Bullet");
            bulletManager.addBullet();
        }

        if (other.tag == "Road")
        {
            spawnManager.SpawnTriggerEntered();
            trafficSpawner.TransferTraffic();
            bulletSpawner.TransferBullet();
        }
    }

    private void Move()
    {
        
        float hMovement = Input.GetAxis("Horizontal") / 2;
        float vMovement = 1;

        SetSpeed();

        Vector3 move = transform.position + new Vector3(hMovement, 0, vMovement) * _speed * Time.deltaTime;

        //if out of limits, move only forward
        if (move.x < 8.9 && move.x > -8.9) _rigidbody.MovePosition(move);
        else _rigidbody.MovePosition(transform.position + new Vector3(0, 0, vMovement) * _speed * Time.deltaTime);        
    }

    public Rigidbody GetRigidbody()
    {
        return this._rigidbody;
    }

    private void SetSpeed()
    {
        float time = timeManager.getTime();
        if (time < 30)
        {
            _speed = Mathf.RoundToInt((30 + time));
        }
        else if (time < 60)
        {
            _speed = Mathf.RoundToInt((50 + (time / 3)));
        }
        else
        {
            _speed = Mathf.RoundToInt((60 + (time / 6)));
        }
    }

    private IEnumerator SetInvulnerable()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(2f);
        _isInvulnerable = false;
    }
}
