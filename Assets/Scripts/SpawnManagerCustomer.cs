using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManagerCustomer : MonoBehaviour
{
    public GameObject[] spawnCustumer;
    public GameObject[] tablesArray;
    private Tables tables;
    private TableOnly tablesOnly;
    private GameObject Table1;
    private GameObject Table2;
    private GameObject Table3;
    private bool a;
    public float timeRespawn;

    void Start()
    {
        InvokeRepeating("setAvailableTable", 25, timeRespawn);

        Table1 = GameObject.Find("Table1");
        Table2 = GameObject.Find("Table2");
        Table3 = GameObject.Find("Table3");
    }

    void Update()
    {
        SpawnManager();
    }

    void SpawnManager()
    {
        int minArray = 0;
        int maxArray = 3;

        if (Table1.GetComponent<TableOnly>().available)
        {
            int indexArray = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table1.transform.position.x, Table1.transform.position.y);
            Instantiate(spawnCustumer[indexArray], spawnPos, spawnCustumer[indexArray].transform.rotation);
            Table1.GetComponent<TableOnly>().available = false;
        }
        else if (Table2.GetComponent<TableOnly>().available)
        {
            int indexArray2 = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table2.transform.position.x, Table2.transform.position.y);
            Instantiate(spawnCustumer[indexArray2], spawnPos, spawnCustumer[indexArray2].transform.rotation);
            Table2.GetComponent<TableOnly>().available = false;
        }
        else if (Table3.GetComponent<TableOnly>().available)
        {
            int indexArray3 = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table3.transform.position.x, Table3.transform.position.y);
            Instantiate(spawnCustumer[indexArray3], spawnPos, spawnCustumer[indexArray3].transform.rotation);
            Table3.GetComponent<TableOnly>().available = false;
        }
    }

    void setAvailableTable()
    {
        if (Table1.GetComponent<TableOnly>().available == false)
        {
            Table1.GetComponent<TableOnly>().available = true;
        }

        if (Table2.GetComponent<TableOnly>().available == false)
        {
            Table2.GetComponent<TableOnly>().available = true;
        }

        if (Table3.GetComponent<TableOnly>().available == false)
        {
            Table3.GetComponent<TableOnly>().available = true;
        }
    }

    IEnumerator LifeCustomerdownRoutine()
    {
        yield return new WaitForSeconds(3);
    }
}