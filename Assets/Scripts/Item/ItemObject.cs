using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ItemManager.instance.AddItem(this);
    }

    //�ش� �������� ����� �� ������ ����
    public void OnPickUp()
    {

    }
}
