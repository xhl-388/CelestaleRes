using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationTower : Tower
{
    private void Awake()
    {
        MoneyController.instance.efficiency += 0.5f;
    }
    public override void BeDestroyed()
    {
        MoneyController.instance.efficiency -= 0.5f;
        base.BeDestroyed();
    }
}
