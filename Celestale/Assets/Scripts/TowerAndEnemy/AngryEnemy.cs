using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that firstly attack strongest tower
/// </summary>
public class AngryEnemy : AttackEnemy
{
    protected override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius, towerLayer);
        float highestAbility=0;
        int index=0;
        for(int i = 0; i < colliders.Length; i++)
        {
            float x;
            if ((x=colliders[i].GetComponent<Tower>().GetAbilityNowValue()) > highestAbility)
            {
                highestAbility = x;
                index = i;
            }
        }
        if (highestAbility != 0f)
        {
            colliders[index].GetComponent<Tower>().GetDamaged(attack * attackRate);
        }
        state = State.Move;
    }
}
