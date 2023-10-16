using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomize : MonoBehaviour
{
    [SerializeField] private Button btnColors;
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnColors.onClick.AddListener(Open_Colors);
        btnColors.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnBack.onClick.AddListener(Close_Customize);
        btnBack.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Open_Colors()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIColors>();
    }

    private void Close_Customize()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIStart>();
    }
}
