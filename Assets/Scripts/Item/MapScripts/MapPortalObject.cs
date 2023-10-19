using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextMapPortalObject : MonoBehaviour
{
    [SerializeField] private int destination;
    /// <summary>
    /// 해당 플레이어 캐릭터가 맵 이동 오브젝트와 충돌했을 때 호출될 이벤트. 
    /// 추후 필요한 동작을 추가할 수 있도록 해 두었음.
    /// </summary>
    [SerializeField] private UnityEvent OnNextMap;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn pr = other.transform.GetComponent<PlayerRespawn>();

            if (pr != null)
            {
                OnNextMap?.Invoke();
                pr.RespawnPlayer();
            }
            else
            {
                Debug.Log("Is not Player");
            }
        }
        else
        {
            ItemObject item = other.transform.GetComponent<ItemObject>();
            if (item != null)
            {
                OnItemLost?.Invoke();
                ItemManager.instance.RespawnItem(item);
            }
            else
            {
                Debug.Log("Is not Item");
            }
        }
    }
}
