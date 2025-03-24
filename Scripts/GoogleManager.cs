using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;



public class GoogleManager : MonoBehaviour
{
    public static GoogleManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();
    }

    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            string id = PlayGamesPlatform.Instance.GetUserId();
            string ImgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();
        }
    }

    public void ShowLeaderboardUI() // 리더보드 열기
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_rank);
    }

    public void AddScore(int score) // 리더보드에 점수 추가
    {
        PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard_rank, (bool success) => { });
    }
}