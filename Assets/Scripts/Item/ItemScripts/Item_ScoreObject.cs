using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ScoreObject : ItemObject
{
    //private bool isUp = true;
    //private float minRange;
    //private float maxRange;
    //private const float LEVITATION_RANGE = 1;
    private const float TICK = 0.005f;

    private void Awake()
    {
        //maxRange = gameObject.transform.position.y + LEVITATION_RANGE;
        //minRange = gameObject.transform.position.y - LEVITATION_RANGE;
    }

    private void Start()
    {
        ItemManager.instance.AddItem(gameObject.GetComponent<Item_ScoreObject>());
    }
    // Update is called once per frame
    void Update()
    {
        LevitateItem();
    }

    /// <summary>
    /// 해당 오브젝트를 비활성화시키고 플레이어 스폰포인트 재지정
    /// </summary>
    public new void OnPickUp()
    {
        gameObject.SetActive(false);

    }

    /// <summary>
    /// 해당 오브젝트가 위아래로 움직이고, 회전하도록 하는 메소드
    /// </summary>
    private void LevitateItem()
    {
        Vector3 position = gameObject.transform.position;
        Quaternion rotation = gameObject.transform.rotation;
        
        rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y + (TICK * 80), rotation.eulerAngles.z);

        gameObject.transform.rotation = rotation;

        //if (isUp)
        //{
        //    if (position.y < maxRange)
        //    {
        //        position.y += TICK;
        //        gameObject.transform.position = position;
        //    }
        //    else
        //    {
        //        isUp = false;
        //    }
        //}
        //else
        //{
        //    if (position.y > minRange)
        //    {
        //        position.y -= TICK;
        //        gameObject.transform.position = position;
        //    }
        //    else
        //    {
        //        isUp = true;
        //    }
        //}
    }
}
