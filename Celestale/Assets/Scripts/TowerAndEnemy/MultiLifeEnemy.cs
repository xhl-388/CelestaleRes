using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that has three lives,become weaker when killed
/// </summary>
public class MultiLifeEnemy :AttackEnemy,IImpassible
{
    private int life=3;
    private bool isImpassible = false;
    public override void GetDamaged(float damage)
    {
        if(!isImpassible)
        base.GetDamaged(damage);
    }
    protected override void BeDestroyed()
    {
        if (life > 1)
        {
            HpNow = Hp;
            attackRate -= 0.2f;
            life--;
            GiveImpassibleBuff(1f);
        }
        else
        {
            base.BeDestroyed();
        }
    }
    public bool IsImpassible()
    {
        return isImpassible;
    }
    public void SetImpassible(bool isImpassible)
    {
        this.isImpassible = isImpassible;
    }
    public void GiveImpassibleBuff(float time)
    {
        StartCoroutine(BuffController.ImpassibleBuff(this, time));
    }
}
