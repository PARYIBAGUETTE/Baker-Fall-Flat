using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ScoreObject : ItemObject
{

    private bool isUp = true;
    private float minRange;
    private float maxRange;
    private const float LEVITATION_RANGE = 1;
    private const float TICK = 0.005f;

    private void Awake()
    {
        maxRange = gameObject.transform.position.y + LEVITATION_RANGE;
        minRange = gameObject.transform.position.y - LEVITATION_RANGE;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevitateItem();
    }

    /// <summary>
    /// �ش� ������Ʈ�� ��Ȱ��ȭ��Ű�� �÷��̾��� ���� ī��Ʈ ����
    /// </summary>
    public void OnPickUp()
    {
        
        gameObject.SetActive(false);

        //�÷��̾��� ���� ī��Ʈ ����
    }

    /// <summary>
    /// �ش� ������Ʈ�� ���Ʒ��� �����̰�, ȸ���ϵ��� �ϴ� �޼ҵ�
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
