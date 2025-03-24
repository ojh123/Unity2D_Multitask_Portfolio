using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class ScoreManager : MonoBehaviour
{
    private string highScoreKey = "HighScore"; // 최고 점수를 저장할 키
    private string firstLaunchKey = "FirstLaunch"; // 첫 실행 여부 확인 키

    void Awake()
    {
        // 첫 실행이면 PlayerPrefs 초기화
        if (!PlayerPrefs.HasKey(firstLaunchKey))
        {
            PlayerPrefs.DeleteAll(); // 모든 데이터 초기화
            PlayerPrefs.SetInt(firstLaunchKey, 1); // 첫 실행 여부 저장
            PlayerPrefs.Save(); // 변경 사항 저장
        }
    }

    // 최고 점수를 저장
    public void SaveHighScore(int score)
    {
        // 기존 최고 점수보다 높은 경우에만 업데이트
        if (score > PlayerPrefs.GetInt(highScoreKey, 0))
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            GoogleManager.instance.AddScore(score);

        }
    }

    // 최고 점수를 불러오기
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScoreKey, 0); // 저장된 최고 점수를 반환
    }
}
