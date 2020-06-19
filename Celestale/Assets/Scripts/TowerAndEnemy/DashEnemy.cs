using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemy that won't positivly attack tower
/// </summary>
public class DashEnemy :Enemy
{
    protected virtual void Awake()
    {
        InitEnemy();
    }
    protected virtual void Update()
    {
        if (IsDizz())
        {
            return;
        }
        Move();
    }
    private void Move()
    {
        transform.Translate(transition*Time.deltaTime*speed);
        //if(Vector2.Distance(transform.position,way[wayIndex])==0f)
    }
}
