using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private bool isGrabbed;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ItemManager.instance.AddItem(this);
    }

    public bool IsGrabbed
    {
        get { return isGrabbed; }
        set { isGrabbed = value; }
    }

    //�ش� �������� ����� �� ������ ����
    public void OnPickUp()
    {
        IsGrabbed = true;
    }
}
