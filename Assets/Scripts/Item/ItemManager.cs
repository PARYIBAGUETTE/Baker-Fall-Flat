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

    //���� ���� ��� ������ ������ �����Ѵ�. 
    //�����۰� �� ����� �浹, ���� ���� ��ȣ�ۿ� �� �߻��ϴ� �̺�Ʈ�� �ٷ��.

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
