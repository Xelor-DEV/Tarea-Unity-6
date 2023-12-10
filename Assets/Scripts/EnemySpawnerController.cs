using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameManagerController gameManager;
    public float xMin;
    public float xMax;
    private float x_position_generation;
    void Start()
    {
        Invoke("CreateEnemy", 2);
    }
    void CreateEnemy()
    {
        x_position_generation = Random.Range(xMin, xMax);
        GameObject tmp = Instantiate(enemyPrefab,new Vector2(x_position_generation, 3.9f),enemyPrefab.transform.rotation);
        tmp.GetComponent<EnemyController>().SetGameManager(gameManager);
        Invoke("CreateEnemy", 2);
    }
}
