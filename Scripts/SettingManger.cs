using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingManger : MonoBehaviour
{
    // 셋팅버튼 클릭시 켜질 오브젝트
    [SerializeField]
    private GameObject go_Settings;

    [SerializeField]
    Image soundImage;

    private void Start()
    {
        // 저장된 투명도 값 불러오기 (없으면 기본값 1)
        float alpha = PlayerPrefs.GetFloat("SoundButtonAlpha", 1f);
        SetSoundButtonAlpha(alpha);
    }


    // 셋팅 버튼 클릭
    public void ClickSettings()
    {
        SoundManager.instance.PlayButtonClickSound();
        go_Settings.SetActive(true);  // 셋팅 패널 활성화
        Time.timeScale = 0f; // 게임 멈추기
    }

    // 셋팅 패널 닫기
    public void CloseSettings()
    {
        SoundManager.instance.PlayButtonClickSound();
        go_Settings.SetActive(false);  // 셋팅 패널 활성화
        Time.timeScale = 1f; // 게임 재개
    }

    // 다시하기 버튼클릭
    public void ClickReplay()
    {
        SoundManager.instance.PlayButtonClickSound();
        Time.timeScale = 1f; // 게임 재개
        SceneChanger.instance.SceneChange(1);
    }

    // 소리 버튼 클릭
    public void ClickSound()
    {
        if (SoundManager.instance.bgmAudioSource.volume == SoundManager.instance.bgmVolume) // 소리가 켜져 있으면 음소거
        {
            SoundManager.instance.bgmAudioSource.volume = 0f;
            SetSoundButtonAlpha(0.5f); // 투명도 0.5로 변경
        }
        else // 음소거 상태면 다시 소리킴
        {
            SoundManager.instance.bgmAudioSource.volume = SoundManager.instance.bgmVolume;
            SetSoundButtonAlpha(1f); // 투명도 1로 변경
        }
    }
    // 홈 버튼 클릭
    public void ClickHome()
    {
        SoundManager.instance.PlayButtonClickSound();
        Time.timeScale = 1f; // 게임 재개
        SceneChanger.instance.SceneChange(0);
    }

    // 랭킹 버튼 클릭
    public void ClickRank()
    {
        SoundManager.instance.PlayButtonClickSound();
        GoogleManager.instance.ShowLeaderboardUI();
    }

    private void SetSoundButtonAlpha(float alpha)
    {
        soundImage.color = new Color(soundImage.color.r, soundImage.color.g, soundImage.color.b, alpha);
        PlayerPrefs.SetFloat("SoundButtonAlpha", alpha); // 변경된 투명도 저장
        PlayerPrefs.Save();
    }

}
