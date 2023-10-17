using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColors : MonoBehaviour
{
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(Close_Colors);
        btnBack.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Close_Colors()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UICustomize>();
    }
}
