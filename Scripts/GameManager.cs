using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> games; // 게임을 담을 리스트
    [SerializeField]
    private List<Camera> cameras; // 각 게임들의 카메라 리스트

    [SerializeField]
    private ScoreManager scoreManager; // ScoreManager 참조

    [SerializeField]
    private float gameTime; // 게임 진행 시간

    // 각 게임이 시작되었는지 여부를 나타내는 변수
    private bool game2Start = false;
    private bool game3Start = false;
    private bool game4Start = false;

    // 게임오버시 띄울 스코어 보드
    [SerializeField]
    private GameObject go_Score;
    [SerializeField]
    private Text scoreTimeText; // 스코어 보드의 시간 텍스트

    [SerializeField]
    private Text timeText; // 시간 텍스트
    [SerializeField]
    private Text bestTimeText; // 최고 시간 텍스트


    private void Start()
    {
        bestTimeText.text = "Best Time : " + scoreManager.GetHighScore().ToString();
    }

    private void Update()
    {
        UpdateTime();
        if (gameTime > 15f && !game2Start)
        {
            Game2Start();
        }
        else if (gameTime > 30f && !game3Start)
        {
            Game3Start();
        }
        else if (gameTime > 45f && !game4Start)
        {
            Game4Start();
        }

        
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        timeText.text = "Time : " + gameTime.ToString("F0");
    }

    private void Game2Start()
    {
        game2Start = true;
        games[1].SetActive(true);

        // 게임 1 
        cameras[0].rect = new Rect(0f, 0f, 0.5f, 1f);  // 좌측 화면 배치

        // 게임 2 
        cameras[1].rect = new Rect(0.5f, 0f, 0.5f, 1f);  // 우측 화면 배치

    }

    private void Game3Start()
    {
        game3Start = true;
        games[2].SetActive(true);

        // 게임 1 
        cameras[0].rect = new Rect(0f, 0.5f, 0.5f, 1f);  // 좌측 위쪽 화면 배치

        // 게임 3 
        cameras[2].rect = new Rect(0f, 0f, 0.5f, 0.5f);  // 좌측 아래 화면 배치
    }

    private void Game4Start()
    {
        game4Start = true;
        games[3].SetActive(true);

        // 게임 2 
        cameras[1].rect = new Rect(0.5f, 0.5f, 1f, 1f);  // 우측 위쪽 화면 배치

        // 게임 4 
        cameras[3].rect = new Rect(0.5f, 0f, 1f, 0.5f);  // 우측 아래 화면 배치
    }

    public void GameEnd(int _num)
    {
        scoreManager.SaveHighScore(((int)gameTime));
        ActiveGameOver(_num);
    }

    private void ActiveGameOver(int _num)
    {
        go_Score.SetActive(true);
        scoreTimeText.text = "Time : " + gameTime.ToString("F0");
        Time.timeScale = 0f;
    }

}
