using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationTower : Tower
{
    //private AudioSource audioSource;
    //private float nextPlayTime;
    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        MoneyController.instance.efficiency += 0.5f;
    }
    private void Start()
    {
        //nextPlayTime = Time.time + 2f;
    }
    public override void BeDestroyed()
    {
        MoneyController.instance.efficiency -= 0.5f;
        base.BeDestroyed();
    }
    //private void Update()
    //{
    //    if (Time.time > nextPlayTime)
    //    {
    //        audioSource.Play();
    //        nextPlayTime = Time.time + 2f;
    //    }
    //}
}
