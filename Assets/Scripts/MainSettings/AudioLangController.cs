using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLangController : MonoBehaviour
{
    public static AudioLangController current;
    public static AudioSource audioSource;
    public bool audioSystem = true;
    public bool restart = false;
    public bool english;
    public bool portuguese;
    public bool spanish;

    private void Awake()
    {
        current = this;
        audioSystem = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        if (restart && Victory.audioPlaying || restart && GameOver.audioPlaying)
        {
            audioSystem = false;
            audioSource.Stop();
        }
        if (restart && !Victory.audioPlaying || restart && !GameOver.audioPlaying)
        {
            audioSystem = true;
            audioSource.Stop();
        }
    }
}
