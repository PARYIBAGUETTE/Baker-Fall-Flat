using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Box : ItemObject
{
    private void Start()
    {
        ItemManager.instance.AddItem(gameObject.GetComponent<Item_Box>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
