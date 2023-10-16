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

    private void Awake()
    {
        btnStart.onClick.AddListener(GameStart);
        btnStart.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnOption.onClick.AddListener(Open_Option);
        btnOption.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnCustomize.onClick.AddListener(Open_Customize);
        btnCustomize.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void GameStart()
    {
        SceneManager.LoadScene("UI"); // temporary
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
}
