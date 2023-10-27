using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] int pointValue;
    public float currentHealth {  get; private set; }

    private bool dead;
    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
            gameManager.UpdateScore(pointValue);
        }
        
    }
}
