using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float Hp;         //生命上限
    protected float HpNow;      //当前生命值
    [SerializeField]
    protected float armor;  //敌人的护甲
    public void GetDamaged(float damage)
    {

    }
    private void BeDestroyed()
    {

    }
}
