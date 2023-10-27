using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] GameObject spawnBegginPos;
    private GameManager gameManager;
    
    private void Awake()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            Instantiate(enemyList[i], spawnBegginPos.transform.position, Quaternion.identity);
            enemyList[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
