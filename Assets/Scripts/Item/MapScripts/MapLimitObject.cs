using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapLimitObject : MonoBehaviour
{
    /// <summary>
    /// 해당 아이템이 맵의 지정된 범위를 벗어났을 때 호출될 이벤트.
    /// </summary>
    public UnityEvent OnItemLost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
        }
        else
        {
            ItemObject item = other.transform.GetComponent<ItemObject>();
            if (item != null)
            {
                ItemManager.instance.RespawnItem(item);
            }
        }
    }
}
