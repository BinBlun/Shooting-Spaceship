using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] GameObject spawnBegginPos;
    /*[SerializeField] GameObject firstPos;
    [SerializeField] GameObject enemy;

    [SerializeField] float duration = 2.0f;
    public List<Vector3> childPositions;*/

    private void Awake()
    {
        SpawnTarget();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*childPositions = new List<Vector3>();

        Transform[] children = firstPos.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            // Skip the parent itself
            if (child == firstPos.transform) continue;

            // Retrieve the position of each child GameObject
            childPositions.Add(child.position);
        }*/
    }

    private void Update()
    {
        
    }

    void SpawnTarget()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            Instantiate(enemyList[i], spawnBegginPos.transform.position, Quaternion.identity);
        }
    }

    /*IEnumerator MoveObject(GameObject objectToMove, Vector3 startPosition, Vector3 endPosition, float duration)
    {
        if (childPositions.Count != enemyList.Count)
        {
            Debug.LogError(childPositions);
            Debug.LogError(enemyList.Count);
            Debug.LogError("The number of positions and objects does not match.");
            yield break;
        }

        float time = 0.0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, time / duration); 
            yield return null;
        }
        objectToMove.transform.position = endPosition; // Ensure the object reaches the exact position
    }*/

}
