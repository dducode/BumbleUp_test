using UnityEngine;
using Random = UnityEngine.Random;

namespace BumbleUp.Core {

    public class EnemySpawner : MonoBehaviour {

        [SerializeField]
        private Enemy enemyPrefab;

        [SerializeField]
        private float spawnPeriod = 5;

        private ObjectPool<Enemy> m_enemyPool;
        private Transform[] m_stairsChunks;
        private float m_lastSpawnTime;


        public void Construct (Transform[] stairsChunks, Character character) {
            m_stairsChunks = stairsChunks;
            m_enemyPool = new ObjectPool<Enemy>(
                () => {
                    Enemy enemy = Instantiate(enemyPrefab);
                    enemy.Construct(m_enemyPool);
                    return enemy;
                },
                enemy => enemy.gameObject.SetActive(true),
                enemy => enemy.gameObject.SetActive(false)
            );
            character.Death += () => enabled = false;
        }


        private void Start () {
            m_lastSpawnTime = spawnPeriod;
        }


        private void Update () {
            if (m_lastSpawnTime + spawnPeriod < Time.time) {
                SpawnEnemy();
                m_lastSpawnTime = Time.time;
            }
        }


        private void SpawnEnemy () {
            Vector3 position = m_stairsChunks[m_stairsChunks.Length - 1].position;
            position.y += 20;
            Enemy enemy = m_enemyPool.Get();
            enemy.transform.SetPositionAndRotation(position, Random.rotation);
        }

    }

}