using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkUpTower : Tower
{
    private LayerMask enemyLayer;
    private float nextAttackTime;
    private State state;
    private Animator anim;
    private AudioSource audioSource;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        InitTower();
        enemyLayer =1<< LayerMask.NameToLayer("Enemy");
        nextAttackTime = Time.time + shootSpeedNow;
    }
    enum State
    {
        Idle,
        Attack
    }
    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            bool killed = false;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0f, enemyLayer);
            for(int i = 0; i < colliders.Length; i++)
            {
                Enemy enemy = colliders[i].GetComponent<Enemy>();
                if (enemy.GetHpNow() < enemy.GetHp() * 0.5f)
                {
                    Debug.Log("Killed");
                    state = State.Attack;
                    enemy.KilledByKing();
                    killed = true;
                }
            }
            if (killed == true)
            {
                audioSource.Play();
            }
            nextAttackTime = Time.time + shootSpeedNow;
        }
        else
        {
            state = State.Idle;
        }
        SetAnim();
    }
    
    protected void SetAnim()
    {
        if (state == State.Idle)
        {
            if (anim.GetBool("IsAttacking"))
                anim.SetBool("IsAttacking", false);
        }
        else
        {
            if (!anim.GetBool("IsAttacking"))
                anim.SetBool("IsAttacking", true);
        }
    }
}
