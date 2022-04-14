using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningEnemy : AttackEnemy
{
    [SerializeField]
    private float burningDamage;
    [SerializeField]
    private float burningTime;
    protected override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(attackRadius,attackRadius),0, towerLayer);
        if (colliders.Length != 0)
        {
            int attackT = Random.Range(0, colliders.Length);
            colliders[attackT].GetComponent<Tower>().GetDamaged(attack * attackRate);
            colliders[attackT].GetComponent<Tower>().StartCoroutine(BuffController.BurningBuff(colliders[attackT].gameObject, burningDamage, burningTime));
        }
        state = State.Move;
    }
}
