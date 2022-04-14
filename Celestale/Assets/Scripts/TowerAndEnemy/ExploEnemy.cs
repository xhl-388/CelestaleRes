using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that will cause explode when killed
/// </summary>
public class ExploEnemy : DashEnemy
{
    private LayerMask towerLayer;
    public float exploDamage;
    protected override void Awake()
    {
        base.Awake();
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
    }
    protected override void BeDestroyed()
    {
        Explode();
        base.BeDestroyed();
    }
    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(3f, 3f), 0, towerLayer);
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Tower>().GetDamaged(exploDamage * attackRate);
        }
    }
    protected override void Update()
    {
        base.Update();
    }
}
