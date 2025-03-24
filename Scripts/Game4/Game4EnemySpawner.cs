using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnAreaMin; // ���� ���� �ּҰ� (X, Y)
    [SerializeField]
    private Vector3 spawnAreaMax; // ���� ���� �ִ밪 (X, Y)

    [SerializeField]
    private GameObject go_EnemyPrefab; // �� ������

    [SerializeField]
    private float spawnTime;  // ���� �ð�


    [SerializeField]
    private List<GameObject> enemyList; // ������ƮǮ�� ���� ����Ʈ

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            var clone = Instantiate(go_EnemyPrefab, transform.position, Quaternion.identity);
            clone.transform.SetParent(transform);
            enemyList.Add(clone);
            clone.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyCor());
    }

    private IEnumerator SpawnEnemyCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);  // spawnTime���� ���

            // Ȱ��ȭ���� ���� ���� ã�� ���� ��ġ���� Ȱ��ȭ
            GameObject enemyToSpawn = ActiveEnemy();


            if (enemyToSpawn != null)
            {
                Vector3 randomSpawnPos = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);

                enemyToSpawn.transform.localPosition = randomSpawnPos;
                enemyToSpawn.SetActive(true);  // �� Ȱ��ȭ
            }
        }
    }

    // ��Ȱ��ȭ�� ���� ã�� ��ȯ
    private GameObject ActiveEnemy()
    {
        foreach (var enemy in enemyList)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        return null;
    }
}



