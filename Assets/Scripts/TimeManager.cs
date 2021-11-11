using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{

    public Text playTimeText;
    private float howLong;
    private int howLongRounded;
    private string playTimeString;



    // Start is called before the first frame update
    void Start()
    {
        playTimeString = "Time: " + howLongRounded;
    }

    // Update is called once per frame
    void Update()
    {
        howLong += Time.deltaTime;
        howLongRounded = Mathf.RoundToInt(howLong);
        playTimeString = "Time: " + howLongRounded + " seconds";
        playTimeText.text = playTimeString;
    }

    public int getTime()
    {
        return howLongRounded;
    }
}
