using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    float shakeSpeed;
    float divider;
    float interval;
    float horizontalSpeedX;
    float horizontalDividerX;
    float horizontalIntervalX;
    float xOriginalPos;
    float yOriginalPos;
    public float delayTime;

    private void Awake()
    {
        shakeSpeed = Random.Range(3.5f, 4.5f);
        divider = Random.Range(1f, 2.5f);
        interval = Random.Range(2.5f, 4.5f);
        horizontalSpeedX = Random.Range(0.01f, 1f);
        horizontalDividerX = Random.Range(0.1f, 2.5f);
        horizontalIntervalX = Random.Range(4.5f, 6.5f);
        Debug.Log(shakeSpeed);
        xOriginalPos = transform.position.x;
        yOriginalPos = transform.position.y;
    }
    private void Start()
    {
        InvokeRepeating("_UpDownMovement", delayTime,0.02f);
    }
    public void Update()
    {
        
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        _UpDownMovement();
    }
    public void _UpDownMovement()
    {
        float x = Mathf.Cos((horizontalSpeedX / horizontalDividerX) * Time.time) / horizontalIntervalX;
        float y = Mathf.Sin((shakeSpeed / divider) * Time.time) / interval;

        float xCos = Mathf.Cos((shakeSpeed / divider) * Time.time) / interval;
        transform.position = new Vector3(xOriginalPos + x, yOriginalPos + y, transform.position.z);
    }
}


