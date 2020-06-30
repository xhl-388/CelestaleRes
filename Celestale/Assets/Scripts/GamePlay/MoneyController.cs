using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance { private set; get; }
    public int Money { private set; get; }
    private float moneyFloat;
    private GameObject UI_Money;
    private void Awake()
    {
        UI_Money = GameObject.FindWithTag("UI_Money");
        Money = 0;
        moneyFloat = 0f;
        instance = this;
    }
    private void Update()
    {
        UpdateMoney();
        moneyFloat += Time.deltaTime * 4f;
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
        Money += get;
    }
    public void UpdateMoney()
    {
        UI_Money.GetComponent<Text>().text = Money.ToString();
    }
}
