using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTowerController : MonoBehaviour
{
    public static BuildTowerController instance { private set; get; }
    public GameObject nextBuildTower;
    private bool[] canBePut;
    private void Awake()
    {
        canBePut = new bool[10];
        for(int i = 0; i < 10; i++)
        {
            canBePut[i] = true;
        }
        instance = this;
    }
    private void Update()
    {
        
    }
    public void EnterCD(int index)
    {
       
    }
}
