using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance { private set; get; }
    public int Money { private set; get; }
    private float moneyFloat;
    private void Awake()
    {
        Money = 0;
        moneyFloat = 0f;
        instance = this;
    }
    private void Update()
    {
        moneyFloat += Time.deltaTime * 4f;
        Money = (int)moneyFloat;
    }
    public void CostMoney(int cost)
    {
        Money -= cost;
        if (Money < 0)
        {
            Debug.LogError("Money not enough");
        }
    }
    public void GetMoney(int get)
    {
        Money += get;
    }
}
