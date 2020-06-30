using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyArry;
    private TimePointEnemy[] thisStageEnemy;
    private bool enemyAllOut = false;
    private float nextCheckTime;
    private void Start()
    {
        thisStageEnemy = StageEnemy.instance.enemySpawnArry[SceneManager.GetActiveScene().buildIndex];
        StartCoroutine(SpawnEnemy());
        //buildindex存在差值
    }
    private void Update()
    {
        if (enemyAllOut)
        {
            if (Time.time > nextCheckTime)
            {
                Check();
                nextCheckTime = Time.time + 1f;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < thisStageEnemy.Length; i++)
        {
            yield return new WaitForSeconds(thisStageEnemy[i].time);
            Instantiate(EnemyArry[thisStageEnemy[i].enemyIndex], transform);
        }
        enemyAllOut = true;
        nextCheckTime = Time.time;
    }
    private void Check()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            GameObject.FindWithTag("UI").GetComponent<UIChange>().Success();
        }
    }
}
