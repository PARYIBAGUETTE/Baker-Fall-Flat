using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary<string, GameObject> _uiList = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject uiStart;

    private void Awake()
    {
        Instance = this;

        InitUIList();
    }

    void InitUIList()
    {
        int uiCount = transform.childCount;
        for (int i = 0; i < uiCount; i++)
        {
            var tr = transform.GetChild(i);
            _uiList.Add(tr.name, tr.gameObject);
            tr.gameObject.SetActive(false);
        }

        if (uiStart != null) _uiList.Add(uiStart.name, uiStart);
    }

    public T OpenUI<T>()
    {
        var obj = _uiList[typeof(T).Name];
        obj.SetActive(true);
        return obj.GetComponent<T>();
    }

    public void CloseUI<T>()
    {
        var obj = _uiList[typeof(T).Name];
        obj.SetActive(false);
    }

    public bool IsOpenUI<T>()
    {
        return _uiList[typeof(T).Name].activeSelf;
    }
}