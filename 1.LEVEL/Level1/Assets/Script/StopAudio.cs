using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    void Start()
    {
        DontDestroy.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    void Update()
    {
    }
}
