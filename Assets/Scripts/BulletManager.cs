using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{

    private int bulletAmount = 3;
    public Text bulletAmountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string bulletAmountString = "Bullets: " + bulletAmount;
        bulletAmountText.text = bulletAmountString;
    }

    public void addBullet()
    {
        bulletAmount++;
    }
}
