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
        }
    }

    //현재 맵의 모든 아이템 정보를 보유한다. 
    //아이템과 맵 요소의 충돌, 눌림 등의 상호작용 시 발생하는 이벤트를 다룬다.

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemObject item)
    {
        items.Add(item);
    }
}
