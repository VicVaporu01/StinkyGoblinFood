using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyCustomer : MonoBehaviour
{
    private PlayerController playerControllerScript;

    private Tables tables;
    private Rigidbody step;
    private GameObject Table;
    private GameObject Table2;
    private GameObject Table3;
    private TableOnly asd;
    public float waitTime;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        step = GetComponent<Rigidbody>();
        asd = FindObjectOfType<TableOnly>();
        Table2 = GameObject.Find("Table2");
        Table3 = GameObject.Find("Table3");
    }

    void Update()
    {
        DestroyCustomerd();
    }

    void DestroyCustomerd()
    {
        StartCoroutine(LifeCustomerdownRoutine());
    }

    IEnumerator LifeCustomerdownRoutine()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        playerControllerScript.LoseHealth();
    }
}