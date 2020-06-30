using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController instance { private set; get; }
    [SerializeField]
    private int health = 10;
    private void Awake()
    {
        instance = this;
    }
    public void GetDamaged()
    {
        health--;
        if (health == 0)
        {
            Fail();
        }
    }
    public void Fail()
    {
        GameObject.FindWithTag("UI").GetComponent<UIChange>().Fail();
    }
}
