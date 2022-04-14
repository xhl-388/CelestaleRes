using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliverController : MonoBehaviour
{
    private LayerMask buildAreaLayer;
    private bool isReady;
    private void Awake()
    {
        buildAreaLayer = 1 << LayerMask.NameToLayer("BuildArea");
    }
    private void Update()
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, buildAreaLayer);
                if (collider!=null)
                {
                    BuildArea buildArea = collider.GetComponent<BuildArea>();
                    if (buildArea.hasOccupied)
                    {
                        MoneyController.instance.GetMoney(buildArea.occupyTower.GetComponent<Tower>().cancelGain);
                        buildArea.occupyTower.GetComponent<Tower>().BeDestroyed();
                    }
                }
                isReady = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                isReady = false;
            }
        }
    }
    public void ReadyToRemove()
    {
        isReady = true;
    }
}
