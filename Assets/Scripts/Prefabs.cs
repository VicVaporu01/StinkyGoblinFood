using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            Debug.Log("good");
        }
        else
        {
            Debug.Log("Se destruyo");
        }
    }
}
