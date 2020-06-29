using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSpeedUpTower : AttackTower
{
    private List<GameObject> helpTower = new List<GameObject>();
    private LayerMask towerLayer;
    private float nextGetTime;
    private void GetTower()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0, towerLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (!helpTower.Contains(colliders[i].gameObject))
            {
                helpTower.Add(colliders[i].gameObject);
                Tower tower = colliders[i].gameObject.GetComponent<Tower>();
                tower.SetShootSpeedNow(tower.GetShootSpeedNow() * 0.8f);
            }
        }
    }
    protected override void Awake()
    {
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
        base.Awake();
    }
    protected override void Start()
    {
        GetTower();
        nextGetTime = Time.time + 3f;
        base.Start();
    }
    protected override void Update()
    {
        if (Time.time > nextGetTime)
        {
            GetTower();
            nextGetTime = Time.time + 3f;
        }
        base.Update();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
    public override void BeDestroyed()
    {
        for(int i = 0; i < helpTower.Count; i++)
        {
            if (helpTower[i] != null)
            {
                Tower tower = helpTower[i].GetComponent<Tower>();
                tower.SetShootSpeedNow(tower.GetShootSpeedNow() * 1.25f);
            }
        }
        base.BeDestroyed();
    }
}
