using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroCamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject VCam1;
    [SerializeField] GameObject VCam2;
    IEnumerable KameraGecis()
    {
        yield return new WaitForSeconds(12*Time.deltaTime);
        VCam1.SetActive(false);
        VCam2.SetActive(true);
    }
    void Start()
    {
        StartCoroutine("KameraGecis");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
