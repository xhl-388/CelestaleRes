using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDUpdate : MonoBehaviour
{
    public bool canBePut = true;
    public float Cd;
    public float nextArrangeTime;
    private void Update()
    {
        if (!canBePut)
        {
            if (Time.time > nextArrangeTime)
            {
                canBePut = true;
                GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    public void EnterCD()
    {
        canBePut = false;
        nextArrangeTime = Time.time + Cd;
        GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
}
