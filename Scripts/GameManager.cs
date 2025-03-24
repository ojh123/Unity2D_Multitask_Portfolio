using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> games; // ������ ���� ����Ʈ
    [SerializeField]
    private List<Camera> cameras; // �� ���ӵ��� ī�޶� ����Ʈ

    [SerializeField]
    private ScoreManager scoreManager; // ScoreManager ����

    [SerializeField]
    private float gameTime; // ���� ���� �ð�

    // �� ������ ���۵Ǿ����� ���θ� ��Ÿ���� ����
    private bool game2Start = false;
    private bool game3Start = false;
    private bool game4Start = false;

    // ���ӿ����� ��� ���ھ� ����
    [SerializeField]
    private GameObject go_Score;
    [SerializeField]
    private Text scoreTimeText; // ���ھ� ������ �ð� �ؽ�Ʈ

    [SerializeField]
    private Text timeText; // �ð� �ؽ�Ʈ
    [SerializeField]
    private Text bestTimeText; // �ְ� �ð� �ؽ�Ʈ


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

        // ���� 1 
        cameras[0].rect = new Rect(0f, 0f, 0.5f, 1f);  // ���� ȭ�� ��ġ

        // ���� 2 
        cameras[1].rect = new Rect(0.5f, 0f, 0.5f, 1f);  // ���� ȭ�� ��ġ

    }

    private void Game3Start()
    {
        game3Start = true;
        games[2].SetActive(true);

        // ���� 1 
        cameras[0].rect = new Rect(0f, 0.5f, 0.5f, 1f);  // ���� ���� ȭ�� ��ġ

        // ���� 3 
        cameras[2].rect = new Rect(0f, 0f, 0.5f, 0.5f);  // ���� �Ʒ� ȭ�� ��ġ
    }

    private void Game4Start()
    {
        game4Start = true;
        games[3].SetActive(true);

        // ���� 2 
        cameras[1].rect = new Rect(0.5f, 0.5f, 1f, 1f);  // ���� ���� ȭ�� ��ġ

        // ���� 4 
        cameras[3].rect = new Rect(0.5f, 0f, 1f, 0.5f);  // ���� �Ʒ� ȭ�� ��ġ
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
