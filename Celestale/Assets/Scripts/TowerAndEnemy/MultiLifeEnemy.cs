using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that has three lives,become weaker when killed
/// </summary>
public class MultiLifeEnemy :AttackEnemy
{
    private int life=3;
    protected override void BeDestroyed()
    {
        if (life > 1)
        {
            HpNow = Hp;
            attackRate -= 0.2f;
            life--;
            //短暂无敌效果待写
        }
        else
        {
            base.BeDestroyed();
        }
    }
}
