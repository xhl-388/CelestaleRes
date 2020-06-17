using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the basic class of all the enemies
/// </summary>
public class Enemy : MonoBehaviour,IArmorChange,IAttackedRateChange,IAbilityRateChange,IDizziness
{
    [SerializeField]
    protected float Hp;         //生命上限
    protected float HpNow;      //当前生命值
    private bool isDizz=false;
    [SerializeField]
    protected float armor;      //敌人的护甲
    protected float attackedRate;
    protected float attackRate;
    protected virtual void InitEnemy()
    {
        attackedRate = 1f;
        attackRate = 1f;
        HpNow = Hp;
    }
    public void GetDamaged(float damage)
    {
        float trueDamage = (damage * attackedRate - armor) <= 0 ? 0 : (damage * attackedRate - armor);
        HpNow = Mathf.Clamp(HpNow - trueDamage, 0f, Hp);
        if (HpNow == 0)
        {
            BeDestroyed();
        }
    }
    protected virtual void BeDestroyed()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }



    public float GetArmorNow()
    {
        return armor;
    }
    public void SetArmorNow(float armor)
    {
        this.armor = armor;
    } 
    public float GetAttackedRate()
    {
        return attackedRate;
    }
    public void SetAttackedRate(float attackedRate)
    {
        this.attackedRate = attackedRate;
    }
    public float GetAbilityRate()
    {
        return attackRate;
    }
    public void SetAbilityRate(float abilityRate)
    {
        attackRate = abilityRate;
    }
    public bool IsDizz()
    {
        return isDizz;
    }
    public void SetDizz(bool isDizz)
    {
        this.isDizz = isDizz;
    }
}
