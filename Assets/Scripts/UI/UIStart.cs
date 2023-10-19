using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnOption;
    [SerializeField] private Button btnCustomize;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnStart.onClick.AddListener(Open_Select);
        btnStart.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnOption.onClick.AddListener(Open_Option);
        btnOption.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnCustomize.onClick.AddListener(Open_Customize);
        btnCustomize.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnQuit.onClick.AddListener(Quit_Game);
        btnQuit.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Open_Select()
    {
        UIManager.Instance.OpenUI<UISelect>();
        this.gameObject.SetActive(false);
    }

    private void Open_Option()
    {
        UIManager.Instance.OpenUI<UIOption>();
        this.gameObject.SetActive(false);
    }

    private void Open_Customize()
    {
        UIManager.Instance.OpenUI<UICustomize>();
        this.gameObject.SetActive(false);
    }

    private void Quit_Game()
    {
        Application.Quit();
    }
}
