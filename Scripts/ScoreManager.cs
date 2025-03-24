using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class ScoreManager : MonoBehaviour
{
    private string highScoreKey = "HighScore"; // �ְ� ������ ������ Ű
    private string firstLaunchKey = "FirstLaunch"; // ù ���� ���� Ȯ�� Ű

    void Awake()
    {
        // ù �����̸� PlayerPrefs �ʱ�ȭ
        if (!PlayerPrefs.HasKey(firstLaunchKey))
        {
            PlayerPrefs.DeleteAll(); // ��� ������ �ʱ�ȭ
            PlayerPrefs.SetInt(firstLaunchKey, 1); // ù ���� ���� ����
            PlayerPrefs.Save(); // ���� ���� ����
        }
    }

    // �ְ� ������ ����
    public void SaveHighScore(int score)
    {
        // ���� �ְ� �������� ���� ��쿡�� ������Ʈ
        if (score > PlayerPrefs.GetInt(highScoreKey, 0))
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            GoogleManager.instance.AddScore(score);

        }
    }

    // �ְ� ������ �ҷ�����
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScoreKey, 0); // ����� �ְ� ������ ��ȯ
    }
}
