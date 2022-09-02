using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScreenAudioController : MonoBehaviour
{
    void Update()
    {
        if (!AudioLangController.current.audioSystem)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }
}
