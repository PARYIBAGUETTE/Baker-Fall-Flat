using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    [SerializeField] private Button btnAudio;
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnAudio.onClick.AddListener(Open_Audio);
        btnBack.onClick.AddListener(Close_Option);
    }

    private void Open_Audio()
    {
        UIManager.Instance.OpenUI<UIAudio>();
        this.gameObject.SetActive(false);
    }

    private void Close_Option()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIStart>();
    }
}
