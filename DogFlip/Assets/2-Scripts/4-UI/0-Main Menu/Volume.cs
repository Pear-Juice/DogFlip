using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel (float slidervalue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(slidervalue) * 20);
    }
}
