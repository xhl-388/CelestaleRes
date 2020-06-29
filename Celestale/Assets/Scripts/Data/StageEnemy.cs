using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnemy
{
    private static StageEnemy _instance = new StageEnemy();
    public static StageEnemy instance { get { return _instance; } }
    public TimePointEnemy[][] enemySpawnArry=new TimePointEnemy[9][];
    private StageEnemy()
    {
        enemySpawnArry[0] = new TimePointEnemy[7];
        enemySpawnArry[0][0] = new TimePointEnemy(1f, 0);
        enemySpawnArry[0][1] = new TimePointEnemy(3f, 6);
        enemySpawnArry[0][2] = new TimePointEnemy(5f, 5);
        enemySpawnArry[0][3] = new TimePointEnemy(2f, 1);
        enemySpawnArry[0][4] = new TimePointEnemy(3f, 2);
        enemySpawnArry[0][5] = new TimePointEnemy(4f, 3);
        enemySpawnArry[0][6] = new TimePointEnemy(5f, 4);
    }
}
public struct TimePointEnemy
{
    public float time { private set; get; }
    public int enemyIndex { private set; get; }
    public TimePointEnemy(float time,int enemyIndex)
    {
        this.time = time;
        this.enemyIndex = enemyIndex;
    }
}
