using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game4Enemy : MonoBehaviour
{
    [SerializeField]
    TextMeshPro numText;

    [SerializeField]
    private float count;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(NumCountCor());
    }

    IEnumerator NumCountCor()
    {
        count = 10f;
        while (count > 0)
        {
            count -= Time.deltaTime;
            numText.text = Mathf.Ceil(count).ToString();
            yield return null;
        }
        numText.text = "0";
        gameManager.GameEnd(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
