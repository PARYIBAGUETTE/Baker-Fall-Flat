using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NextMapPortalObject : MonoBehaviour
{
    [SerializeField] private int destinationIndex;
    /// <summary>
    /// 해당 플레이어 캐릭터가 맵 이동 오브젝트와 충돌했을 때 호출될 이벤트. 
    /// 추후 필요한 동작을 추가할 수 있도록 해 두었음.
    /// </summary>
    [SerializeField] private UnityEvent OnNextMap;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    OnNextMap?.Invoke();
        //    SceneManager.LoadScene(destinationIndex);
        //}
        if (other.transform.GetComponent<PlayerRespawn>() != null)
        {
            OnNextMap?.Invoke();
            SceneManager.LoadScene(destinationIndex);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.Log("Is not Player");
        }
    }
}
