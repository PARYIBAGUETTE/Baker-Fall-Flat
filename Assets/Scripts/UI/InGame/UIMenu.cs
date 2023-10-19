using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnLoadCheckPoint;
    [SerializeField] private Button btnOptionInGame;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnResume.onClick.AddListener(Resume_Game);
        btnResume.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnRestart.onClick.AddListener(Restart_Game);
        btnRestart.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnLoadCheckPoint.onClick.AddListener(LoadCheckPoint);
        btnLoadCheckPoint.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnOptionInGame.onClick.AddListener(Open_Option);
        btnOptionInGame.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
        btnExit.onClick.AddListener(Exit_Level);
        btnExit.onClick.AddListener(() => SoundManager.Insatance.SfxPlay("Button"));
    }

    private void Resume_Game()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Restart_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadCheckPoint()
    {
        return;
    }

    private void Open_Option()
    {
        UIManager.Instance.OpenUI<UIOptionInGame>();
        this.gameObject.SetActive(false);
    }

    private void Exit_Level()
    {
        SceneManager.LoadScene(0);
    }
}
