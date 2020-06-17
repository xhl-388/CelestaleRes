using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the base of all the towers
/// </summary>
public class Tower : MonoBehaviour,IAbilityChange,IAbilityRateChange,IAttackedRateChange,IShootSpeedChange,IDizziness
{
    [SerializeField]
    protected float Hp;             //生命值上限
    protected float HpNow;          //当前生命值
    public bool isFullHp { get { return Hp == HpNow; } }
    private bool isDizz = false;
    [SerializeField]
    protected float shootSpeed;     //射速（同时也是减益buff的施加速度和生命恢复塔的生命恢复速度）
    protected float shootSpeedNow;  //当前射速
    [SerializeField]
    protected float shootRadius;    //射击半径（同射速，是作用半径）
    [SerializeField]
    protected float abilityValue;   //能力值（攻击伤害，减益效率，生命恢复效率）
    protected float abilityValueNow;//当前能力值
    protected float abilityRate;    //能力倍率
    protected float beAttackedRate; //收到伤害的倍率
    [SerializeField]
    protected int arrangeCost;      //部署花费
    [SerializeField]
    protected int cancelGain;       //消除的费用返还
    public virtual void Act(object o)               //行为（包括攻击，施加减益，回血）
    {
        Debug.LogWarning("No upper component!");
    }
    public void BeDestroyed()               //被摧毁
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    public void GetDamaged(float damage)                        //受到攻击
    {
        HpNow = Mathf.Clamp(HpNow-damage*beAttackedRate, 0f, Hp);
        if (HpNow == 0f)
        {
            BeDestroyed();
        }
    }
    public void GetHealed(float resume)                         //收到治疗效果
    {
        HpNow = Mathf.Clamp(HpNow + resume, 0, Hp);
    }
    protected void InitTower()                      //初始化变量
    {  
        HpNow = Hp;
        shootSpeedNow = shootSpeed;
        abilityValueNow = abilityValue;
        abilityRate = 1f;
        beAttackedRate = 1f;

        BoxCollider2D collider;
        if ((collider = GetComponent<BoxCollider2D>()) != null)
        {
            collider.size = new Vector2(shootRadius, shootRadius);
        }
        else Debug.LogError("Collider missing!");

    }
    public float GetAbilityNowValue()
    {
        return abilityValueNow;
    }



    public float GetAbilityNow()
    {
        return abilityValueNow;
    }
    public void SetAbilityNow(float ability)
    {
        abilityValueNow = ability;
    }
    public float GetAbilityRate()
    {
        return abilityRate;
    }
    public void SetAbilityRate(float abilityRate)
    {
        this.abilityRate = abilityRate;
    }
    public float GetAttackedRate()
    {
        return beAttackedRate;
    }
    public void SetAttackedRate(float attackedRate)
    {
        beAttackedRate = attackedRate;
    }
    public float GetShootSpeedNow()
    {
        return shootSpeedNow;
    }
    public void SetShootSpeedNow(float shootSpeed)
    {
        shootSpeedNow = shootSpeed;
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
