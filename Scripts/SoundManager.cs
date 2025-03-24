using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmAudioSource; // BGM 전용 오디오 소스
    public AudioSource sfxAudioSource; // 효과음 전용 오디오 소스

    [SerializeField]
    private AudioClip btnClickSound; // 버튼 클릭 사운드
    [SerializeField]
    private AudioClip bgmSound; // 배경음악

    public float bgmVolume = 0.3f; // BGM 사운드 크기

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmAudioSource.volume = bgmVolume;
        PlayBGM();
    }

    public void PlayBGM()  // 배경음악 재생
    {
        if (bgmAudioSource != null && bgmSound != null)
        {
            bgmAudioSource.clip = bgmSound;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
    }

    public void StopBGM() // 배경음악 정지
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }
    }

    public void PlayButtonClickSound()  // 버튼 클릭 사운드
    {
        if (sfxAudioSource != null && btnClickSound != null)
        {
            sfxAudioSource.PlayOneShot(btnClickSound);
        }
    }
}
