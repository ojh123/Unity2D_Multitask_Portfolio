using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemySpawnPos; // ������ġ
    private int spawnIndex; // �����迭 �ε���

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
            yield return new WaitForSeconds(spawnTime);  // spawnTime���� ���

            // Ȱ��ȭ���� ���� ���� ã�� ���� ��ġ���� Ȱ��ȭ
            GameObject enemyToSpawn = ActiveEnemy();
            

            if (enemyToSpawn != null)
            {
                // �������� ���� ��ġ�� ����
                spawnIndex = Random.Range(0, enemySpawnPos.Length);
                if (spawnIndex > 4) // �ε����� 4���� ũ�� ������ �ݴ�� ����
                {
                    enemyToSpawn.GetComponent<Game2Enemy>().direction = -1;
                }
                Transform spawnPos = enemySpawnPos[spawnIndex]; // ������ġ ����
                   

                // �� ��ġ ����
                enemyToSpawn.transform.position = spawnPos.position;
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

   

