using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tower that can heal other towers
/// </summary>
public class HealTower : Tower
{
    private GameObject healTarget;
    private LayerMask towerLayer;

    private float nextHealTime;
    private float nextSearchTime;
    private State state;
    private Animator anim;
    enum State
    {
        Idle,
        Heal
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        InitTower();
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
    }
    private void Start()
    {
        nextHealTime = Time.time + shootSpeedNow;
        nextSearchTime = Time.time + 3f;
        SearchTowerNeedHeal();
    }
    private void Update()
    {
        if (IsDizz())
        {
            if (state == State.Heal)
            {
                state = State.Idle;
            }
            SetAnim();
            return;
        }
        if (Time.time > nextSearchTime)
        {
            SearchTowerNeedHeal();
            nextSearchTime = Time.time + 3f;
        }
        if (healTarget != null)
        {
            if (Time.time > nextHealTime)
            {
                Act(healTarget);
                nextHealTime = Time.time + shootSpeedNow;
            }
        }
        else
        {
            state = State.Idle;
            nextHealTime = Time.time + shootSpeedNow;
        }
        SetAnim();
    }
    private void SetAnim()
    {
        if (state == State.Idle)
        {
            if (anim.GetBool("IsHealing"))
            {
                anim.SetBool("IsHealing", false);
            }
        }
        else
        {
            if (!anim.GetBool("IsHealing"))
            {
                anim.SetBool("IsHealing", true);
            }
        }
    }
    public override void Act(GameObject o)      //行为：治疗友方
    {
        Debug.Log("Heal");
        state = State.Heal;
        o.GetComponent<Tower>().GetHealed(abilityValueNow*abilityRate);
    }
    private void SearchTowerNeedHeal()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0f,towerLayer);
        float minDistance=100;
        if (colliders.Length == 1)
        {
            healTarget = null;
            return;
        }
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject)
            {
                continue;
            }
            if (!colliders[i].GetComponent<Tower>().isFullHp)
            {
                float x;
                if ((x=Vector2.Distance(transform.position, colliders[i].transform.position) )< minDistance)
                {
                    minDistance = x;
                    healTarget = colliders[i].gameObject;
                }
            }
        }
        if (minDistance == 0)
        {
            healTarget = null;
        }
    }
}
