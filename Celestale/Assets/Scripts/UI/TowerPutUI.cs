using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPutUI : MonoBehaviour
{
    public GameObject[] towers;

    private bool isReadyToPut=false;
    private LayerMask buildAreaLayer;
    private void Awake()
    {
        buildAreaLayer = 1 << LayerMask.NameToLayer("BuildArea");
    }
    private void Update()
    {
        if (isReadyToPut)
        {
            if (Input.GetMouseButtonDown(1))
            {
                isReadyToPut = false;
                BuildTowerController.instance.nextBuildTower = null;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Collider2D collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, buildAreaLayer);
                if (collider!=null)
                {
                    BuildArea buildArea = collider.GetComponent<BuildArea>();
                    if (buildArea.hasOccupied)
                    {
                        isReadyToPut = false;
                        BuildTowerController.instance.nextBuildTower = null;
                    }
                    else
                    {
                        GameObject obj = Instantiate(BuildTowerController.instance.nextBuildTower, buildArea.transform);
                        MoneyController.instance.CostMoney(obj.GetComponent<Tower>().arrangeCost);
                        buildArea.hasOccupied = true;
                        buildArea.occupyTower = obj;
                    }
                }
                else
                {
                    isReadyToPut = false;
                    BuildTowerController.instance.nextBuildTower = null;
                }
            }
        }
    }
    public void ReadyTower1()
    {
        BuildTowerController.instance.nextBuildTower = towers[0];
        isReadyToPut = true;
    }
    public void ReadyTower2()
    {
        BuildTowerController.instance.nextBuildTower = towers[1];
        isReadyToPut = true;
    }
    public void ReadyTower3()
    {
        BuildTowerController.instance.nextBuildTower = towers[2];
        isReadyToPut = true;
    }
    public void ReadyTower4()
    {
        BuildTowerController.instance.nextBuildTower = towers[3];
        isReadyToPut = true;
    }
    public void ReadyTower5()
    {
        BuildTowerController.instance.nextBuildTower = towers[4];
        isReadyToPut = true;
    }
    public void ReadyTower6()
    {
        BuildTowerController.instance.nextBuildTower = towers[5];
        isReadyToPut = true;
    }
    public void ReadyTower7()
    {
        BuildTowerController.instance.nextBuildTower = towers[6];
        isReadyToPut = true;
    }
    public void ReadyTower8()
    {
        BuildTowerController.instance.nextBuildTower = towers[7];
        isReadyToPut = true;
    }
    public void ReadyTower9()
    {
        BuildTowerController.instance.nextBuildTower = towers[8];
        isReadyToPut = true;
    }
    public void ReadyTower10()
    {
        BuildTowerController.instance.nextBuildTower = towers[9];
        isReadyToPut = true;
    }
}
