using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioInGame : MonoBehaviour
{
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(Close_Audio);
        btnBack.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Close_Audio()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIOptionInGame>();
    }
}
