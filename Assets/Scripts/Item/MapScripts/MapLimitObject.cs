using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapLimitObject : MonoBehaviour
{
    /// <summary>
    /// 해당 아이템, 플레이어 캐릭터가 맵의 지정된 범위를 벗어났을 때 호출될 이벤트. 
    /// 추후 필요한 동작을 추가할 수 있도록 해 두었음.
    /// </summary>
    [SerializeField] private UnityEvent OnItemLost;
    [SerializeField] private UnityEvent OnPlayerLost;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerRespawn pr = other.transform.GetComponent<PlayerRespawn>();

            if(pr != null)
            {
                OnPlayerLost?.Invoke();
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
