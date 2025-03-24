using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingManger : MonoBehaviour
{
    // ���ù�ư Ŭ���� ���� ������Ʈ
    [SerializeField]
    private GameObject go_Settings;

    [SerializeField]
    Image soundImage;

    private void Start()
    {
        // ����� ���� �� �ҷ����� (������ �⺻�� 1)
        float alpha = PlayerPrefs.GetFloat("SoundButtonAlpha", 1f);
        SetSoundButtonAlpha(alpha);
    }


    // ���� ��ư Ŭ��
    public void ClickSettings()
    {
        SoundManager.instance.PlayButtonClickSound();
        go_Settings.SetActive(true);  // ���� �г� Ȱ��ȭ
        Time.timeScale = 0f; // ���� ���߱�
    }

    // ���� �г� �ݱ�
    public void CloseSettings()
    {
        SoundManager.instance.PlayButtonClickSound();
        go_Settings.SetActive(false);  // ���� �г� Ȱ��ȭ
        Time.timeScale = 1f; // ���� �簳
    }

    // �ٽ��ϱ� ��ưŬ��
    public void ClickReplay()
    {
        SoundManager.instance.PlayButtonClickSound();
        Time.timeScale = 1f; // ���� �簳
        SceneChanger.instance.SceneChange(1);
    }

    // �Ҹ� ��ư Ŭ��
    public void ClickSound()
    {
        if (SoundManager.instance.bgmAudioSource.volume == SoundManager.instance.bgmVolume) // �Ҹ��� ���� ������ ���Ұ�
        {
            SoundManager.instance.bgmAudioSource.volume = 0f;
            SetSoundButtonAlpha(0.5f); // ���� 0.5�� ����
        }
        else // ���Ұ� ���¸� �ٽ� �Ҹ�Ŵ
        {
            SoundManager.instance.bgmAudioSource.volume = SoundManager.instance.bgmVolume;
            SetSoundButtonAlpha(1f); // ���� 1�� ����
        }
    }
    // Ȩ ��ư Ŭ��
    public void ClickHome()
    {
        SoundManager.instance.PlayButtonClickSound();
        Time.timeScale = 1f; // ���� �簳
        SceneChanger.instance.SceneChange(0);
    }

    // ��ŷ ��ư Ŭ��
    public void ClickRank()
    {
        SoundManager.instance.PlayButtonClickSound();
        GoogleManager.instance.ShowLeaderboardUI();
    }

    private void SetSoundButtonAlpha(float alpha)
    {
        soundImage.color = new Color(soundImage.color.r, soundImage.color.g, soundImage.color.b, alpha);
        PlayerPrefs.SetFloat("SoundButtonAlpha", alpha); // ����� ���� ����
        PlayerPrefs.Save();
    }

}
