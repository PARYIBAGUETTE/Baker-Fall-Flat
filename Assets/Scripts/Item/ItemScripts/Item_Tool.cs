using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Tool : ItemObject
{
    private void Start()
    {
        ItemManager.instance.AddItem(gameObject.GetComponent<Item_Tool>());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
