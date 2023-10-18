using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionInGame : MonoBehaviour
{
    [SerializeField] private Button btnAudio;
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnAudio.onClick.AddListener(Open_Audio);
        btnAudio.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnBack.onClick.AddListener(Close_Option);
        btnBack.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Open_Audio()
    {
        UIManager.Instance.OpenUI<UIAudio>();
        this.gameObject.SetActive(false);
    }

    private void Close_Option()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
