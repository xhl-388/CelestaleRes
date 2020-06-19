using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    protected float speed;

    protected Vector2 transition;
    protected Vector2[] way;
    protected int wayIndex;
    protected virtual void InitEnemy()
    {
        MapData.instance.mapDic.TryGetValue(SceneManager.GetActiveScene().buildIndex,out way);
        wayIndex = 0;
        transition = new Vector2(way[0].x - transform.position.x, way[0].y - transform.position.y);
        //这里的buildindex很可能具有一个差值
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
    public void GiveArmorChangeBuff(float change,float time)
    {
        StartCoroutine(BuffController.ArmorBuff(this, change, time));
    }
    public float GetAttackedRate()
    {
        return attackedRate;
    }
    public void SetAttackedRate(float attackedRate)
    {
        this.attackedRate = attackedRate;
    }
    public void GiveAttackedRateChangeBuff(float change,float time)
    {
        StartCoroutine(BuffController.AttackedRateBuff(this, change, time));
    }
    public float GetAbilityRate()
    {
        return attackRate;
    }
    public void SetAbilityRate(float abilityRate)
    {
        attackRate = abilityRate;
    }
    public void GiveAttackRateChangeBuff(float change,float time)
    {
        StartCoroutine(BuffController.AttackRateBuff(this, change, time));
    }
    public bool IsDizz()
    {
        return isDizz;
    }
    public void SetDizz(bool isDizz)
    {
        this.isDizz = isDizz;
    }
    public void GiveDizzBuff(float time)
    {
        StartCoroutine(BuffController.CantMoveBuff(this, time));
    }
}
