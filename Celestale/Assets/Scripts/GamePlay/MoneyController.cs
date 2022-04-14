using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance { private set; get; }
    public int Money { private set; get; }
    private float moneyFloat;
    public int startMoney;
    private GameObject UI_Money;
    [HideInInspector]
    public float efficiency = 1;
    private void Awake()
    {
        UI_Money = GameObject.FindWithTag("UI_Money");
        moneyFloat =startMoney;
        Money =(int)moneyFloat;
        instance = this;
    }
    private void Update()
    {
        UpdateMoney();
        moneyFloat += Time.deltaTime * 2f *efficiency;
        Money = (int)moneyFloat;
    }
    public void CostMoney(int cost)
    {
        moneyFloat -= cost;
        if (Money < 0)
        {
            Debug.LogError("Money not enough");
        }
    }
    public void GetMoney(int get)
    {
        moneyFloat += get;
    }
    public void UpdateMoney()
    {
        UI_Money.GetComponent<Text>().text = Money.ToString();
    }
}
