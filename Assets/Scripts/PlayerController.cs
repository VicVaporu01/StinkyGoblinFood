using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private FoodSpawnManager foodSpawnManagerScript;

    private Rigidbody2D playerRB;
    private float verticalInput, horizontalInput;
    [SerializeField] private int playerActualFoodScore, countHasDish, playerScore = 0, playerHeath = 5;
    [SerializeField] private bool hasDish = false;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (countHasDish == 3)
        {
            hasDish = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRB.MovePosition(playerRB.position +
                              new Vector2(horizontalInput, verticalInput) * (playerSpeed * Time.fixedDeltaTime));
    }

    public void AddScore(int foodScore)
    {
        if (!hasDish)
        {
            playerActualFoodScore += foodScore;
            countHasDish += 1;
        }

        // Debug.Log("Food Score: " + playerActualFoodScore);
    }

    private void DeliverDish()
    {
        if (hasDish)
        {
            hasDish = false;
            countHasDish = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            if (playerActualFoodScore == -1)
            {
                if (hasDish)
                {
                    Destroy(other.gameObject);
                }
                DeliverDish();
                playerActualFoodScore = 0;
                playerScore += 5;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            DeliverDish();
            playerActualFoodScore = 0;
        }
    }

    // private String CategorizeActualFood()
    // {
    //     if (playerActualFoodScore > 0)
    //     {
    //         return "Tiene comida deliciona.";
    //     }
    //     else if (playerActualFoodScore == -1)
    //     {
    //         return "Tiene comida asquerosa";
    //     }
    //     else
    //     {
    //         return "Tiene comida super Asquerosa";
    //     }
    // }

    public int GetScore()
    {
        return playerScore;
    }

    public int GetHealthPoints()
    {
        return playerHeath;
    }

    public void LoseHealth()
    {
        playerHeath -= 1;
    }

    public bool GetHasDish()
    {
        return hasDish;
    }
    
}