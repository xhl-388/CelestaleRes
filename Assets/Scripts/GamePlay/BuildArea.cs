using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArea : MonoBehaviour
{
    [HideInInspector]
    public bool hasOccupied=false;
    public GameObject occupyTower;
    private void Update()
    {
        if (hasOccupied)
        {
            if (occupyTower == null)
            {
                hasOccupied = false;
            }
        }
    }
}
