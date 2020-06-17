using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEnemy : AttackEnemy
{
    protected override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius, towerLayer);
        if (colliders.Length != 0)
        {
            int attackT = Random.Range(0, colliders.Length);
            colliders[attackT].GetComponent<Tower>().GetDamaged(attack * attackRate);
            //给塔施加燃烧效果待写
        }
        state = State.Move;
    }
}
