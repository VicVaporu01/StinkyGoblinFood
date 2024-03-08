using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyCustomer : MonoBehaviour
{
    private Tables tables;//
    private Rigidbody step;
    private GameObject Table;
    private GameObject Table2;
    private GameObject Table3;
    private TableOnly asd;
    public float waitTime;

    //public GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        //table = table.tables;
        step = GetComponent<Rigidbody>();
        //table = tables.tables[0];
        asd = FindObjectOfType<TableOnly>();
        Table2 = GameObject.Find("Table2");
        Table3 = GameObject.Find("Table3");

    }
                    
    // Update is called once per frame
    void Update()
    {
        
        DestroyCustomerd();
    }

    void DestroyCustomerd()
    {
        StartCoroutine(LifeCustomerdownRoutine());
        //asd.GetComponent<TableOnly>().available=true;
    }

    IEnumerator LifeCustomerdownRoutine()
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
