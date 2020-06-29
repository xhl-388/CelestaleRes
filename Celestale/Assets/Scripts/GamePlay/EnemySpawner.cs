using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyArry;
    private TimePointEnemy[] thisStageEnemy;
    private void Start()
    {
        thisStageEnemy = StageEnemy.instance.enemySpawnArry[SceneManager.GetActiveScene().buildIndex];
        StartCoroutine(SpawnEnemy());
        //buildindex存在差值
    }
    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < thisStageEnemy.Length; i++)
        {
            yield return new WaitForSeconds(thisStageEnemy[i].time);
            Instantiate(EnemyArry[thisStageEnemy[i].enemyIndex], transform);
        }
    }
}
