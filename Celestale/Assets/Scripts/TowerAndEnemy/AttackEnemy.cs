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
    protected Animator anim;

    protected LayerMask towerLayer;
    protected virtual void Start()
    {
        nextAttackTime = Time.time + attackSpeedNow;
    }
    protected enum State
    {
        Move,
        Attack,
        Rest
    }
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
        attackSpeedNow = attackSpeed;
        InitEnemy();
    }
    protected virtual void Update()
    {
        if (IsDizz()||state==State.Rest)
        {
            SetAnim();
            return;
        }
        if (Time.time > nextAttackTime)
        {
            state = State.Attack;
            nextAttackTime = Time.time + attackSpeedNow;
        }
        SetAnim();
        switch (state)
        {
            case State.Attack:Attack();
                break;
            case State.Move:Move();
                break;
        }
    }
    protected void SetAnim()
    {
        if (state == State.Attack)
        {
            if (!anim.GetBool("IsAttacking"))
            {
                anim.SetBool("IsAttacking", true);
            }
        }
        else
        {
            if (anim.GetBool("IsAttacking"))
            {
                anim.SetBool("IsAttacking", false);
            }
        }
    }
    protected virtual void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(attackRadius,attackRadius),0, towerLayer);
        if (colliders.Length != 0)
        {
            int attackT = Random.Range(0, colliders.Length);
            colliders[attackT].GetComponent<Tower>().GetDamaged(attack * attackRate);
            StartCoroutine(RestAfterAttack());
        }
        if(state==State.Attack)
            state = State.Move;
    }
    IEnumerator RestAfterAttack()
    {
        state = State.Rest;
        yield return new WaitForSeconds(0.2f);
        state = State.Move;
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
