using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private float verticalInput, horizontalInput;

    private Rigidbody2D playerRB;
    [SerializeField] private FoodSpawnManager foodSpawnManagerScript;

    public int playerActualFoodScore;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        Debug.Log("Food Score: " + playerActualFoodScore);
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
        playerActualFoodScore += foodScore;
    }
}