using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.System {
    public class Score : MonoBehaviour {
        public static Action<int> increaseScore;

        [SerializeField]
        private Text scoreText = null;

        private int _score = 0;
        private void Start() {
            increaseScore += IncreaseScore;
        }

        private void IncreaseScore(int score) {
            _score += score;
            scoreText.text = $"Score:{_score.ToString()}";
        }
    }
}
