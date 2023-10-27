using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private GameObject[] enemys;
    [SerializeField] GameObject enemy;

    [SerializeField] float duration = 2.0f;
    [SerializeField] List<GameObject> targetPositions;
    /*public List<Vector3> childPositions;*/
    private int currentTargetIndex;
    int countStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        MoveEnemiesToNextPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveEnemiesToNextPosition()
    {

        if (currentTargetIndex >= targetPositions.Count)
        {
            Debug.Log("All positions reached.");
            
            return ;
        }


        if (countStage == currentTargetIndex)
        {
            int count = 0;
            List<Vector3> childPositions = new List<Vector3>();

            Transform[] children = targetPositions[currentTargetIndex].GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                // Skip the parent itself
                if (child == targetPositions[currentTargetIndex].transform) continue;

                // Retrieve the position of each child GameObject
                childPositions.Add(child.position);
            }

            foreach (GameObject enemy in enemys)
            {
                StartCoroutine(MoveObject(enemy, enemy.transform.position, childPositions[count], duration));
                count++;
            }
            countStage++;
            Debug.Log("Moving to position " + currentTargetIndex + ": " + targetPositions[currentTargetIndex].name);
        }
        currentTargetIndex++;
        StartCoroutine(MoveEnemiesToNextPositionCoroutine());
    }


    IEnumerator MoveObject(GameObject objectToMove, Vector3 startPosition, Vector3 endPosition, float duration)
    {
        /*if (childPositions.Count != enemys.Length)
        {
            Debug.LogError(childPositions);
            Debug.LogError(enemys.Length);
            Debug.LogError("The number of positions and objects does not match.");
            yield break;
        }*/

        float time = 0.0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, time / duration);
            yield return null;
        }
        objectToMove.transform.position = endPosition; // Ensure the object reaches the exact position

        /*yield return new WaitForSeconds(5.0f); // Wait for 3 second before moving to the next position

        MoveEnemiesToNextPosition();*/
    }

    IEnumerator MoveEnemiesToNextPositionCoroutine()
    {
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds before moving to the next position
        MoveEnemiesToNextPosition();
    }
}
