using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown dropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentResolution;
        dropdown.RefreshShownValue();
    }

    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void Fullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[dropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		Debug.Log("Set " + resolution + " as new resolution");
	}
}
