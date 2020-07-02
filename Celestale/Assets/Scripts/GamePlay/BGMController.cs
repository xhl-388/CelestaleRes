using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMController : MonoBehaviour
{
    public static BGMController instance { private set; get; }
    private AudioSource audioSource;
    private GameObject UI_BGM;
    private void Awake()
    {
        instance = this;
        UI_BGM = GameObject.FindWithTag("BGMController");
        audioSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 1f);
        }
        else
        {
            audioSource.volume = PlayerPrefs.GetFloat("BGMVolume");
        }
        UI_BGM.GetComponent<Slider>().value = audioSource.volume;
    }
    public void SetVolume()
    {
        audioSource.volume=UI_BGM.GetComponent<Slider>().value;
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("BGMVolume", audioSource.volume);
    }
}
