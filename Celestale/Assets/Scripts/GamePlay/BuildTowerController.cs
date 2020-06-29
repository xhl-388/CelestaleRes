using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTowerController : MonoBehaviour
{
    public static BuildTowerController instance { private set; get; }
    public GameObject nextBuildTower;
    private void Awake()
    {
        instance = this;
    }
}
