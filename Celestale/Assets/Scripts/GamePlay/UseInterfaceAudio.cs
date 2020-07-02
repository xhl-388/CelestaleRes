using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// play music shot
/// </summary>
public class UseInterfaceAudio : MonoBehaviour      //一个播放音效的单例
{
    public static UseInterfaceAudio instance { private set; get; }
    public AudioClip enemyDeath;
    public AudioClip towerDeath;
    public AudioClip click;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
