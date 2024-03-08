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
    private int playerActualFoodScore, countHasDish;
    private bool hasDish = false;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (countHasDish == 3)
        {
            hasDish = true;
            Debug.Log(CategorizeActualFood());
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

        Debug.Log("Food Score: " + playerActualFoodScore);
    }

    private void DeliverDish()
    {
        hasDish = false;
        countHasDish = 0;
    }

    private String CategorizeActualFood()
    {
        if (playerActualFoodScore > 0)
        {
            return "Tiene comida deliciona.";
        }
        else if (playerActualFoodScore == -1)
        {
            return "Tiene comida asquerosa";
        }
        else
        {
            return "Tiene comida super Asquerosa";
        }
    }
}