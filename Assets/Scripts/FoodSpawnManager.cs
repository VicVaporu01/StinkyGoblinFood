using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodPrefabsList;
    [SerializeField] private List<Transform> spawnsPositions;
}