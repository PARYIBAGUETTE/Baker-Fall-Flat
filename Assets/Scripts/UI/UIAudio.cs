using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(Close_Audio);
    }

    private void Close_Audio()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIOption>();
    }
}
