using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the base of all the towers
/// </summary>
public class Tower : MonoBehaviour
{
    [SerializeField]
    protected float Hp;             //生命值上限
    protected float HpNow;          //当前生命值
    public bool isFullHp { get { return Hp == HpNow; } }
    [SerializeField]
    protected float shootSpeed;     //射速（同时也是减益buff的施加速度和生命恢复塔的生命恢复速度）
    protected float shootSpeedNow;  //当前射速
    [SerializeField]
    protected float shootRadius;    //射击半径（同射速，是作用半径）
    [SerializeField]
    protected float abilityValue;   //能力值（攻击伤害，减益效率，生命恢复效率）
    protected float abilityValueNow;//当前能力值
    [SerializeField]
    protected int arrangeCost;      //部署花费
    [SerializeField]
    protected int cancelGain;       //消除的费用返还
    public virtual void Act(object o)               //行为（包括攻击，施加减益，回血）
    {
        Debug.LogWarning("No upper component!");
    }
    public virtual void BeDestroyed()               //被摧毁
    {
        Debug.LogWarning("No upper component!");
    }
    public void GetDamaged()                        //受到攻击
    {

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

        BoxCollider2D collider;
        if ((collider = GetComponent<BoxCollider2D>()) != null)
        {
            collider.size = new Vector2(shootRadius, shootRadius);
        }
        else Debug.LogError("Collider missing!");

    }
}
