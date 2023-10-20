using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Box,
    Plate,
    Tool,
    ScoreObject,
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private ItemType itemType;
    [SerializeField] private float weight;
}


