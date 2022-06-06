using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;
    private void Start()
    {
        StartCoroutine(SiraliOynat());
    }
    public IEnumerator SiraliOynat()
    {
        int i = 0;
        while (i < sounds.Length)
        {
            audioSource.clip = sounds[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            i++;
        }
    }
}
