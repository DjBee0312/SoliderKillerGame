using System;
using System.Linq;
using System.Timers;
using _Code.Color;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.Enemies {
    public class Spawner : MonoBehaviour {
        [SerializeField]
        private Transform leftTransform = null;
        [SerializeField]
        private Transform rightTransform = null;

        [SerializeField]
        private Enemy enemyToSpawn = null;
        [SerializeField]
        private float startTime = 5f;
        [SerializeField]
        private float step = 0.2f;
        private float _timer = 1.5f;

        private void Start() {
            leftTransform.position = new Vector3(leftTransform.position.x, 11, 5);
            rightTransform.position = new Vector3(rightTransform.position.x, 11, 5);
        }

        private void Update() {
            if (_timer <= 0) {
                SpawnEnemy(new Vector3(Random.Range(leftTransform.position.x,rightTransform.position.x),11,5));
                startTime -= step;
                _timer = startTime;
                if (startTime < 1f) {
                    step = 0f;
                }
            }
            _timer -= Time.deltaTime;
        }

        private void SpawnEnemy(Vector3 spawnPos) {
            GameObject newEnemyGameObject = Instantiate(enemyToSpawn.gameObject, spawnPos, Quaternion.identity);
            newEnemyGameObject.TryGetComponent(out Enemy newEnemy);
            EColor randColor = (EColor) Random.Range(0, 3);
            newEnemy.color = randColor;
            newEnemy.SetColor(randColor);
        }
        
    }
}
