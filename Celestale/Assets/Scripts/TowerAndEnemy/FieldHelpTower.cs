using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldHelpTower : Tower
{
    private LayerMask towerLayer;
    private List<GameObject> helpTower = new List<GameObject>();
    private float nextGetTime;
    private void GetTower()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0, towerLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject&&!helpTower.Contains(colliders[i].gameObject))
            {
                helpTower.Add(colliders[i].gameObject);
                Tower tower = colliders[i].GetComponent<Tower>();
                tower.SetAbilityNow(tower.GetAbilityNow() + abilityValue);
            }
        }
    }
    private void Awake()
    {
        towerLayer = 1 << LayerMask.NameToLayer("Tower");
    }
    private void Start()
    {
        GetTower();
        nextGetTime = Time.time + 3f;
    }
    private void Update()
    {
        if (Time.time > nextGetTime)
        {
            GetTower();
            nextGetTime = Time.time + 3f;
        }
    }
    public override void BeDestroyed()
    {
        for(int i = 0; i < helpTower.Count; i++)
        {
            if (helpTower[i] != null)
            {
                Tower tower = helpTower[i].GetComponent<Tower>();
                tower.SetAbilityNow(tower.GetAbilityNow() - abilityValue);
            }
        }
        base.BeDestroyed();
    }
}
