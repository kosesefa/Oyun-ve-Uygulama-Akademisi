using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocker : MonoBehaviour
{
    Vector3 rotationVector;
    void Start()
    {
        rotationVector = new Vector3();
    }

    private float alpha;
    public float multiplier;

    void Update()
    {
        alpha += Time.deltaTime;

        rotationVector.x = Mathf.Cos(alpha);
        rotationVector.z = Mathf.Sin(alpha);

        transform.Rotate(multiplier * rotationVector * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }
}
