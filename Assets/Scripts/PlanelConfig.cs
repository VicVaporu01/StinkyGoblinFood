using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanelConfig : MonoBehaviour
{
    public GameObject panel;

    public void activePanel()
    {
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }
}
