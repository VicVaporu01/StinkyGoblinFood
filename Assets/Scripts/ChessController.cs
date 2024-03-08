using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class ChessController : MonoBehaviour
{
    [SerializeField] private bool isAvailable = true;

    [SerializeField] private GameObject actualFood;
    [SerializeField] private GameObject instantiatedPrefab;
    [SerializeField] private GameObject player;

    private PlayerController playerControllerScript;

    [SerializeField] private float spawnFoodTimer;

    private void Start()
    {
        InstantiateFood();
        playerControllerScript = GetComponent<PlayerController>();
    }

    public void ChangeAvailableStatus()
    {
        isAvailable = !isAvailable;
    }

    public void InstantiateFood()
    {
        if (isAvailable)
        {
            instantiatedPrefab = Instantiate(actualFood, transform.position, transform.rotation);
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
        if (!isAvailable)
        {
            Destroy(instantiatedPrefab);
            ChangeAvailableStatus();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // playerControllerScript.AddScore(other.gameObject.);
        DestroyFood();
        StartCoroutine("GenerateFood");
    }
}