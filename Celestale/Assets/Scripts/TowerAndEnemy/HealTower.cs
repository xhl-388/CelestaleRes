using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tower that can heal other towers
/// </summary>
public class HealTower : Tower
{
    private Tower healTarget;
    private LayerMask towerLayer;

    private float nextHealTime;

    private void Awake()
    {
        InitTower();
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
    }
    private void Start()
    {
        nextHealTime = Time.time + shootSpeedNow;
        SearchTowerNeedHeal();
    }
    private void Update()
    {
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
            nextHealTime = Time.time + shootSpeedNow;
        }
    }
    public override void Act(object o)      //行为：治疗友方
    {
        ((Tower)o).GetHealed(abilityValueNow);
    }
    private void SearchTowerNeedHeal()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0f,towerLayer);
        float minDistance=0;
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
                    healTarget = colliders[i].GetComponent<Tower>();
                }
            }
        }
        if (minDistance == 0)
        {
            healTarget = null;
        }
    }
}
