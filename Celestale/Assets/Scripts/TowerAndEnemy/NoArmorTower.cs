using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoArmorTower : AttackTower
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
    public override void Act(GameObject o)
    {
        GameObject bullet;
        state = State.Attack;
        bullet = Instantiate(bulletOfThis);
        bullet.GetComponent<TowerBullet>().damage = abilityValueNow * abilityRate+o.GetComponent<Enemy>().GetArmorNow();
        bullet.GetComponent<TowerBullet>().targetTransform = o.transform;
    }
}
