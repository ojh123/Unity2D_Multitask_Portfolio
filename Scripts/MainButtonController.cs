using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public void StartBtn() // start 버튼 클릭
    {
        SoundManager.instance.PlayButtonClickSound();
        SceneChanger.instance.SceneChange(1);
    }

    public void RankBtn()  // Rank 버튼 클릭
    {
        GoogleManager.instance.ShowLeaderboardUI();
    }
}
