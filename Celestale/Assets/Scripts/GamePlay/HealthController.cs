using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController instance { private set; get; }
    public int startHealth;
    private int health;
    private GameObject UI_Health;
    private void Awake()
    {
        instance = this;
        UI_Health = GameObject.FindWithTag("UI_Health");
        health = startHealth;
        UI_Health.GetComponent<Text>().text = health.ToString();
    }
    public void GetDamaged(int x)
    {
        health -= x ;
        UI_Health.GetComponent<Text>().text = health.ToString();
        if (health <= 0)
        {
            Fail();
        }
    }
    public void Fail()
    {
        GameObject.FindWithTag("UI").GetComponent<UIChange>().Fail();
    }
    public int GetHealth()
    {
        return health;
    }
}
