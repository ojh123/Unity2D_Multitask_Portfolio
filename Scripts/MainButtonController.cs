using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public void StartBtn() // start ��ư Ŭ��
    {
        SoundManager.instance.PlayButtonClickSound();
        SceneChanger.instance.SceneChange(1);
    }

    public void RankBtn()  // Rank ��ư Ŭ��
    {
        GoogleManager.instance.ShowLeaderboardUI();
    }
}
