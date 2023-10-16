using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Plate : ItemObject
{
    private void Start()
    {
        ItemManager.instance.AddItem(gameObject.GetComponent<Item_Plate>());
    }

    // Update is called once per frame
    void Update()
    {
    }
}
