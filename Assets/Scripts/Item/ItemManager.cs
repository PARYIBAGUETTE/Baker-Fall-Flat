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

    //���� ���� ��� ������ ������ �����Ѵ�. 
    //�����۰� �� ����� �浹, ���� ���� ��ȣ�ۿ� �� �߻��ϴ� �̺�Ʈ�� �ٷ��.

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
}
