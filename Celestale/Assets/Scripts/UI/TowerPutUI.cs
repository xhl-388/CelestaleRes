using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPutUI : MonoBehaviour
{
    public GameObject[] towers;

    private bool isReadyToPut=false;
    private LayerMask buildAreaLayer;
    private GameObject[] cDUpdate;

    private int index;
    private void Awake()
    {
        buildAreaLayer = 1 << LayerMask.NameToLayer("BuildArea");
        cDUpdate = GameObject.FindGameObjectsWithTag("UI_Card");
        for(int i = 0; i < 10; i++)
        {
            cDUpdate[i].GetComponent<CDUpdate>().Cd = towers[i].GetComponent<Tower>().nextArrangeBreak;
        }
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
                        if (MoneyController.instance.Money >= BuildTowerController.instance.nextBuildTower.GetComponent<Tower>().arrangeCost)
                        {
                            Debug.Log(BuildTowerController.instance.nextBuildTower.GetComponent<Tower>().arrangeCost);
                            isReadyToPut = false;
                            cDUpdate[index].GetComponent<CDUpdate>().EnterCD();
                            GameObject obj = Instantiate(BuildTowerController.instance.nextBuildTower, buildArea.transform);
                            BuildTowerController.instance.nextBuildTower = null;
                            MoneyController.instance.CostMoney(obj.GetComponent<Tower>().arrangeCost);
                            buildArea.hasOccupied = true;
                            buildArea.occupyTower = obj;
                        }
                        else
                        {
                            isReadyToPut = false;
                            BuildTowerController.instance.nextBuildTower = null;
                        }
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
        if (cDUpdate[0].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[0];
            isReadyToPut = true;
            index = 0;
        }
        else
        {

        }
    }
    public void ReadyTower2()
    {
        if (cDUpdate[1].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[1];
            isReadyToPut = true;
            index = 1;
        }
        else
        {

        }
    }
    public void ReadyTower3()
    {
        if (cDUpdate[2].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[2];
            isReadyToPut = true;
            index = 2;
        }
        else
        {

        }
    }
    public void ReadyTower4()
    {
        if (cDUpdate[3].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[3];
            isReadyToPut = true;
            index = 3;
        }
        else
        {

        }
    }
    public void ReadyTower5()
    {
        if (cDUpdate[4].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[4];
            isReadyToPut = true;
            index = 4;
        }
        else
        {

        }
    }
    public void ReadyTower6()
    {
        if (cDUpdate[5].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[5];
            isReadyToPut = true;
            index = 5;
        }
        else
        {

        }
    }
    public void ReadyTower7()
    {
        if (cDUpdate[6].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[6];
            isReadyToPut = true;
            index = 6;
        }
        else
        {

        }
    }
    public void ReadyTower8()
    {
        if (cDUpdate[7].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[7];
            isReadyToPut = true;
            index = 7;
        }
        else
        {

        }
    }
    public void ReadyTower9()
    {
        if (cDUpdate[8].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[8];
            isReadyToPut = true;
            index = 8;
        }
        else
        {

        }
    }
    public void ReadyTower10()
    {
        if (cDUpdate[9].GetComponent<CDUpdate>().canBePut)
        {
            BuildTowerController.instance.nextBuildTower = towers[9];
            isReadyToPut = true;
            index = 9;
        }
        else
        {

        }
    }
}
