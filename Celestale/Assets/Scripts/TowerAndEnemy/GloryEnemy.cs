using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that has a glory which can constantly cause damage to tower
/// </summary>
public class GloryEnemy : DashEnemy
{
    private float nextAttackTime;
    [SerializeField]
    private float attackDamage;
    [SerializeField]
    private int frameOnceAttack;
    [SerializeField]
    private float gloryRadius;
    private LayerMask towerLayer;
    protected override void Awake()
    {
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
        base.Awake();
    }
    private void Start()
    {
        nextAttackTime = Time.time + frameOnceAttack * Time.fixedTime;
    }
    protected override void Update()
    {
        if (Time.time > nextAttackTime)
        {
            AttackTower();
            nextAttackTime = Time.time + frameOnceAttack*Time.fixedTime;
        }
        base.Update();
    }
    private void AttackTower()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, gloryRadius, towerLayer);
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Tower>().GetDamaged(attackDamage * attackRate);
        }
    }
}
