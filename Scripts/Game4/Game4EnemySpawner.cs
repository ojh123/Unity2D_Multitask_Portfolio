using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnAreaMin; // 스폰 범위 최소값 (X, Y)
    [SerializeField]
    private Vector3 spawnAreaMax; // 스폰 범위 최대값 (X, Y)

    [SerializeField]
    private GameObject go_EnemyPrefab; // 적 프리팹

    [SerializeField]
    private float spawnTime;  // 스폰 시간


    [SerializeField]
    private List<GameObject> enemyList; // 오브젝트풀을 위한 리스트

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
            yield return new WaitForSeconds(spawnTime);  // spawnTime마다 대기

            // 활성화되지 않은 적을 찾아 스폰 위치에서 활성화
            GameObject enemyToSpawn = ActiveEnemy();


            if (enemyToSpawn != null)
            {
                Vector3 randomSpawnPos = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);

                enemyToSpawn.transform.localPosition = randomSpawnPos;
                enemyToSpawn.SetActive(true);  // 적 활성화
            }
        }
    }

    // 비활성화된 적을 찾아 반환
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



