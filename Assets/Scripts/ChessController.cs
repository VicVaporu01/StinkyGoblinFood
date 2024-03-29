using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class ChessController : MonoBehaviour
{
    [SerializeField] private bool isAvailable = true;

    [SerializeField] private List<GameObject> actualFood;
    [SerializeField] private GameObject instantiatedPrefab;
    [SerializeField] private GameObject player;

    private PlayerController playerControllerScript;

    [SerializeField] private float spawnFoodTimer;

    private void Start()
    {
        InstantiateFood();
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    public void ChangeAvailableStatus()
    {
        isAvailable = !isAvailable;
    }

    public void InstantiateFood()
    {
        if (isAvailable)
        {
            int randomFood = Random.Range(0, actualFood.Count);
            instantiatedPrefab = Instantiate(actualFood[randomFood], transform.position, transform.rotation);
            ChangeAvailableStatus();
        }
    }

    IEnumerator GenerateFood()
    {
        yield return new WaitForSeconds(spawnFoodTimer);
        InstantiateFood();
    }

    private void DestroyFood()
    {
        int score;
        if (!isAvailable)
        {
            score = instantiatedPrefab.GetComponent<FoodController>().foodValue;
            playerControllerScript.AddScore(score);
            Destroy(instantiatedPrefab);
            ChangeAvailableStatus();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerControllerScript.GetHasDish())
        {
            DestroyFood();
            StartCoroutine("GenerateFood");
        }
    }
}