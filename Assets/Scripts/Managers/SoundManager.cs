using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Insatance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [SerializeField] private string[] bgmClipsKeys;
    [SerializeField] private AudioClip[] bgmClipsValues;
    private Dictionary<string, AudioClip> bgmClips;

    [SerializeField] private string[] sfxClipsKeys;
    [SerializeField] private AudioClip[] sfxClipsValues;
    private Dictionary<string, AudioClip> sfxClips;

    private void Awake()
    {
        bgmClips = new Dictionary<string, AudioClip>();
        sfxClips = new Dictionary<string, AudioClip>();

        for (int i = 0; i < bgmClipsKeys.Length; i++)
        {
            bgmClips.Add(bgmClipsKeys[i], bgmClipsValues[i]);
        }

        for (int i = 0; i < sfxClipsKeys.Length; i++)
        {
            sfxClips.Add(sfxClipsKeys[i], sfxClipsValues[i]);
        }

        if (Insatance == null)
        {
            Insatance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BgmPlay(bgmClips[scene.name]);
    }

    private void BgmPlay(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = 1f;
        bgmSource.Play();
    }

    public void SfxPlay(string name)
    {
        if (sfxSource.isPlaying) return;

        sfxSource.clip = sfxClips[name];
        sfxSource.Play();
    }
}
