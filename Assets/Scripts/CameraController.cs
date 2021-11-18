using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float power;
    public float duration;
    public float slowDownFactor;
    public Light environmentLight;

    
    private float actualDuration;
    private Vector3 startPosition;
    private Transform camTransform;
    private bool isShake;
    private float lightIntensitiy;


    // Start is called before the first frame update
    void Start()
    {
        actualDuration = duration;
        camTransform = Camera.main.transform;
        startPosition = camTransform.localPosition;
        isShake = false;
        lightIntensitiy = environmentLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        if (isShake)
        {
            if (actualDuration > 0)
            {
                camTransform.localPosition = startPosition + Random.insideUnitSphere * power;
                actualDuration -= Time.deltaTime * slowDownFactor;
                if (Random.Range(1, 3) == 1)
                {
                    environmentLight.intensity = 0.1f;
                }
                else
                {
                    environmentLight.intensity = 10f;
                }
            }
            else
            {
                actualDuration = duration;
                camTransform.localPosition = startPosition;
                environmentLight.intensity = lightIntensitiy;
                isShake = false;
            }
        }
    }

    public void shakeCamera()
    {
        isShake = true;
    }
}
