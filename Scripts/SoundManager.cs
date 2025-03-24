using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmAudioSource; // BGM ���� ����� �ҽ�
    public AudioSource sfxAudioSource; // ȿ���� ���� ����� �ҽ�

    [SerializeField]
    private AudioClip btnClickSound; // ��ư Ŭ�� ����
    [SerializeField]
    private AudioClip bgmSound; // �������

    public float bgmVolume = 0.3f; // BGM ���� ũ��

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

    public void PlayBGM()  // ������� ���
    {
        if (bgmAudioSource != null && bgmSound != null)
        {
            bgmAudioSource.clip = bgmSound;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
    }

    public void StopBGM() // ������� ����
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }
    }

    public void PlayButtonClickSound()  // ��ư Ŭ�� ����
    {
        if (sfxAudioSource != null && btnClickSound != null)
        {
            sfxAudioSource.PlayOneShot(btnClickSound);
        }
    }
}
