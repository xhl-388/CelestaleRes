using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// play music shot
/// </summary>
public class UseInterfaceAudio : MonoBehaviour      //一个播放音效的单例
{
    private static UseInterfaceAudio instance;

    private AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else instance = this;
        audioSource = GetComponent<AudioSource>();
    }
}
