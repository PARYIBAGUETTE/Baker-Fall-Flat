using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISelect : MonoBehaviour
{
    [SerializeField] private Button[] btnMaps;
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        //for (int i = 0; i < btnMaps.Length; i++)
        //{
        //    btnMaps[i].onClick.AddListener(() => Load_Maps(i + 1));
        //}

        btnMaps[0].onClick.AddListener(() => Load_Maps(1));
        btnMaps[1].onClick.AddListener(() => Load_Maps(2));
        
        btnBack.onClick.AddListener(Close_Select);
        btnBack.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Load_Maps(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void Close_Select()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<UIStart>();
    }
}
