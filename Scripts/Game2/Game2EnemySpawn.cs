using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemySpawnPos; // 스폰위치
    private int spawnIndex; // 스폰배열 인덱스

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
            var clone = Instantiate(go_EnemyPrefab,transform.position ,Quaternion.identity);
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
                // 랜덤으로 스폰 위치를 선택
                spawnIndex = Random.Range(0, enemySpawnPos.Length);
                if (spawnIndex > 4) // 인덱스가 4보다 크면 방향을 반대로 설정
                {
                    enemyToSpawn.GetComponent<Game2Enemy>().direction = -1;
                }
                Transform spawnPos = enemySpawnPos[spawnIndex]; // 스폰위치 설정
                   

                // 적 위치 설정
                enemyToSpawn.transform.position = spawnPos.position;
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

   

