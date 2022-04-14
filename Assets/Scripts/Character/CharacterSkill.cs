using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    private GameObject[] skills;
    private void Awake()
    {
        skills = GameObject.FindGameObjectsWithTag("UI_Skill");
    }
    public void C1S1()
    {
        if (skills[0].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 10)
            {
                Debug.Log("C1S1");
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Tower>().GiveAttackedRateChangeBuff(-0.5f, 10);
                }
                MoneyController.instance.CostMoney(10);
                skills[0].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C1S2()
    {
        if (skills[1].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 20)
            {
                Debug.Log("C1S2");
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Tower>().GiveShieldBuff(HealthController.instance.GetHealth() * 150);
                }
                MoneyController.instance.CostMoney(20);
                skills[1].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C1S3()
    {
        if (skills[2].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 35)
            {
                Debug.Log("C1S3");
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Tower>().GiveImpassibleBuff(15f);
                }
                MoneyController.instance.CostMoney(35);
                skills[2].GetComponent<CDUpdate>().Cd = 999f;
                skills[2].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C2S1()
    {
        if (skills[0].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 15)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Tower>().GiveAttackChangeBuff(200f, 15f);
                }
                MoneyController.instance.CostMoney(15);
                skills[0].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C2S2()
    {
        if (skills[1].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 20)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");
                int index = Random.Range(0, gameObjects.Length);
                gameObjects[index].GetComponent<Tower>().GiveAttackedRateChangeBuff(2f, 15f);
                MoneyController.instance.CostMoney(20);
                skills[1].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C2S3()
    {
        if (skills[2].GetComponent<CDUpdate>().canBePut)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].GetComponent<Enemy>().GetDamaged(900f);
            }
            HealthController.instance.GetDamaged(HealthController.instance.GetHealth() - 1);
            skills[2].GetComponent<CDUpdate>().Cd = 999f;
            skills[2].GetComponent<CDUpdate>().EnterCD();
        }
    }
    public void C3S1()
    {
        if (skills[0].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 20)
            {
                GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < towers.Length; i++)
                {
                    Tower tower = towers[i].GetComponent<Tower>();
                    tower.GiveShootSpeedChangeBuff(-tower.GetShootSpeedNow() * 0.5f, 15f);
                }
                MoneyController.instance.CostMoney(20);
                skills[0].GetComponent<CDUpdate>().Cd = 999f;
                skills[0].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C3S2()
    {
        if (skills[1].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 5)
            {
                StartCoroutine(DoubleMoneyGet());
                MoneyController.instance.CostMoney(5);
                skills[1].GetComponent<CDUpdate>().Cd = 999f;
                skills[1].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    public void C3S3()
    {
        if (skills[2].GetComponent<CDUpdate>().canBePut)
        {
            if (MoneyController.instance.Money >= 30)
            {
                GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemys.Length; i++)
                {
                    enemys[i].GetComponent<Enemy>().GiveDizzBuff(15f);
                }
                MoneyController.instance.CostMoney(30);
                skills[2].GetComponent<CDUpdate>().Cd = 999f;
                skills[2].GetComponent<CDUpdate>().EnterCD();
            }
        }
    }
    IEnumerator DoubleMoneyGet()
    {
        MoneyController.instance.efficiency += 1f;
        yield return new WaitForSeconds(15f);
        MoneyController.instance.efficiency -= 1f;
    }
}
