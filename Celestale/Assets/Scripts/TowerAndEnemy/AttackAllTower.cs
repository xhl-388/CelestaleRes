using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAllTower : AttackTower
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        if (IsDizz())
        {
            state = State.Idle;
            return;
        }
        if (enemyList.Count != 0)
        {
            if (Time.time > nextAttackTime)
            {
                for (int i = 0; i < enemyList.Count; i++)
                    Act(enemyList[i]);
                for (int i = 0; i < defendEnemy.Count; i++)
                    Act(defendEnemy[i]);
                nextAttackTime = Time.time + shootSpeedNow;
            }
            else state = State.Idle;
        }
        else
        {
            state = State.Idle;
            nextAttackTime = Time.time + shootSpeedNow;
        }
        SetAnim();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
