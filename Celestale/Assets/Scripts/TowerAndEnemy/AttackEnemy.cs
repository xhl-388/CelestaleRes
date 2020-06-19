using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that will positivly attack tower
/// </summary>
public class AttackEnemy : Enemy,IAbilityChange,IShootSpeedChange
{
    [SerializeField]
    protected float attackSpeed;
    protected float attackSpeedNow;
    [SerializeField]
    protected float attack;
    [SerializeField]
    protected float attackRadius;

    protected float nextAttackTime;
    protected State state;

    protected LayerMask towerLayer;
    protected virtual void Start()
    {
        nextAttackTime = Time.time + attackSpeed;
    }
    protected enum State
    {
        Move,
        Attack
    }
    protected virtual void Awake()
    {
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
        attackSpeedNow = attackSpeed;
        InitEnemy();
    }
    protected virtual void Update()
    {
        if (IsDizz())
        {
            return;
        }
        if (Time.time > nextAttackTime)
        {
            state = State.Attack;
            nextAttackTime = Time.time + attackSpeed;
        }
        switch (state)
        {
            case State.Attack:Attack();
                break;
            case State.Move:Move();
                break;
        }
    }
    protected virtual void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius, towerLayer);
        if (colliders.Length != 0)
        {
            int attackT = Random.Range(0, colliders.Length);
            colliders[attackT].GetComponent<Tower>().GetDamaged(attack * attackRate);
        }
        state = State.Move;
    }
    private void Move()
    {

    }



    public float GetAbilityNow()
    {
        return attack;
    }
    public void SetAbilityNow(float attack)
    {
        this.attack = attack;
    }
    public void GiveAttackChangeBuff(float change,float time)
    {
        StartCoroutine(BuffController.AttackBuff(this, change, time));
    }
    public float GetShootSpeedNow()
    {
        return attackSpeedNow;
    }
    public void SetShootSpeedNow(float shootSpeed)
    {
        attackSpeedNow = shootSpeed;
    }
    public void GiveAttackSpeedChangeBuff(float change,float time)
    {
        StartCoroutine(BuffController.ShootSpeedBuff(this, change, time));
    }
}
