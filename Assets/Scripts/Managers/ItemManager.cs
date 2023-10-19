using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    private List<ItemObject> items;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            items = new List<ItemObject>();
        }
    }

    //현재 맵의 모든 아이템 정보를 보유한다. 
    //아이템과 맵 요소의 충돌, 눌림 등의 상호작용 시 발생하는 이벤트를 다룬다.

    void Start()
    {
        
    }

    public void AddItem(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
    }

    public void RespawnItem(ItemObject item)
    {
        item.gameObject.transform.position = item.SpawnPoint;
    }
}
