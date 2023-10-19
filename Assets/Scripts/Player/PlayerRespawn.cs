using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Vector3 checkPoint = new Vector3(0, 5, 0);

    public static PlayerRespawn instance;
    [SerializeField] GameObject player;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void SetCheckPoint(Vector3 newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }

    public void RespawnPlayer()
    {
        player.transform.position = checkPoint;
    }
}
