using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManagerCustomer : MonoBehaviour
{
    //SpawnManagerCustomer[] spawnCustumer;
    public GameObject[] spawnCustumer;
    public GameObject[] tablesArray;
    private Tables tables;
    private TableOnly tablesOnly;
    private GameObject Table1;
    private GameObject Table2;
    private GameObject Table3;
    private bool a;
    public float timeRespawn;

    // Start is called before the first frame update
    void Start()
    {
        //table = tables.tables[0];
        InvokeRepeating("setAvailableTable", 12 , timeRespawn);
        //SpawnManager();
        //a = FindObjectOfType<Tables>().available1;
        //a= FindObjectOfType<Tables>().tablesArray1[1];
        //tablesOnly = GetComponent<TableOnly>();

        Table1 = GameObject.Find("Table1");
        Table2 = GameObject.Find("Table2");
        Table3 = GameObject.Find("Table3");
        //tablesOnly = Table1.GetComponent<TableOnly>();




    }

    // Update is called once per frame
    void Update()
    {
        SpawnManager();

        //if(Table1.GetComponent<TableOnly>().available == false)
        //{
        //    Table1.GetComponent<TableOnly>().available = true;
        //}
        //if (Table2.GetComponent<TableOnly>().available == false)
        //{
        //    Table2.GetComponent<TableOnly>().available = true;
        //}
        //if (Table3.GetComponent<TableOnly>().available == false)
        //{
        //    Table3.GetComponent<TableOnly>().available = true;
        //}



        //if (!Table1.GetComponent<TableOnly>().available && !Table2.GetComponent<TableOnly>().available && !Table3.GetComponent<TableOnly>().available)
        //{
        // Table1.GetComponent<TableOnly>().available = true;
        //   Table2.GetComponent<TableOnly>().available = true;
        //    Table3.GetComponent<TableOnly>().available = true;
        //}
    }

    void SpawnManager()
    { 
        int minArray = 0;
        int maxArray = 3;
        //int minCoorX = -3;
        //int maxCoorX = 6;
        //int minCoorY = -3;
        //int maxCoorY = 6;
        //int posX = Random.Range(minCoorX, maxCoorX);
        //int posY = Random.Range(minCoorY, maxCoorY);

        
        
        if (Table1.GetComponent<TableOnly>().available)
        {
            int indexArray = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table1.transform.position.x, Table1.transform.position.y);
            Instantiate(spawnCustumer[indexArray], spawnPos, spawnCustumer[indexArray].transform.rotation);
            Table1.GetComponent<TableOnly>().available = false;
            
        }else if(Table2.GetComponent<TableOnly>().available)
        {
            int indexArray2 = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table2.transform.position.x, Table2.transform.position.y);
            Instantiate(spawnCustumer[indexArray2], spawnPos, spawnCustumer[indexArray2].transform.rotation);
            Table2.GetComponent<TableOnly>().available = false;
            
        }else if (Table3.GetComponent<TableOnly>().available)
        {
            int indexArray3 = Random.Range(minArray, maxArray);
            Vector2 spawnPos = new Vector2(Table3.transform.position.x, Table3.transform.position.y);
            Instantiate(spawnCustumer[indexArray3], spawnPos, spawnCustumer[indexArray3].transform.rotation);
            Table3.GetComponent<TableOnly>().available = false;
            
        }
        /////////

        
        

        ///////////////
        //if (FindObjectOfType<Tables>().tablesArray1[0])
        //{
        //    //for(int i = 0; i < 3;i++)
        //    //{
        //    //    if (tablesArray[i])
        //        //{
        //            Vector2 spawnPos = new Vector2(FindObjectOfType<Tables>().transform.position.x, FindObjectOfType<Tables>().transform.position.y);
        //            Instantiate(spawnCustumer[indexArray], spawnPos, spawnCustumer[indexArray].transform.rotation);
        //        //}

        //    //}


        //}
        //Debug.Log(FindObjectOfType<Tables>().tablesArray1[0].ToString());



        //if (FindObjectOfType<Tables>().tablesArray1[0])
        //{
        //    //for(int i = 0; i < 3;i++)
        //    //{
        //    //    if (tablesArray[i])
        //        //{
        ////            Vector2 spawnPos = new Vector2(FindObjectOfType<Tables>().transform.position.x, FindObjectOfType<Tables>().transform.position.y);
        ////            Instantiate(spawnCustumer[indexArray], spawnPos, spawnCustumer[indexArray].transform.rotation);
        //        //}

        //    //}


        //}
        //Debug.Log(FindObjectOfType<Tables>().tablesArray1[0].ToString());







    }

    void setAvailableTable()
    {
        if(Table1.GetComponent<TableOnly>().available == false)
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

    IEnumerator LifeCustomerdownRoutine() {

        yield return new WaitForSeconds(3);
    }
}
