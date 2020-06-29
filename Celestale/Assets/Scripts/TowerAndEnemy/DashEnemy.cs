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
}
