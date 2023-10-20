using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private bool isGrabbed;
    [SerializeField] private Vector3 spawnPoint;

    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public bool IsGrabbed
    {
        get { return isGrabbed; }
        set { isGrabbed = value; }
    }

    public Vector3 SpawnPoint
    {
        get { return spawnPoint; }
        set { spawnPoint = value; }
    }

    //해당 아이템을 잡았을 때 수행할 내용
    public void OnPickUp()
    {
        IsGrabbed = true;
    }
}
