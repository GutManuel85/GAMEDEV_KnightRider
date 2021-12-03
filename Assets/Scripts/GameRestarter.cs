using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{

    public Light environmentLight;
    private float lightIntensitiy;

    void Start()
    {
        lightIntensitiy = environmentLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            environmentLight.intensity = 1;
            Time.timeScale = 1;
        }
    }
}