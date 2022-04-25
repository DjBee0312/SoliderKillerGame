using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
   public static Action<int> increaseScore;

   [SerializeField]
   private Text scoreText = null;

   private int _score = 0;

   private void Start() {
      increaseScore += IncreaseScore;
      increaseScore?.Invoke(0);
   }

   private void IncreaseScore(int score) {
      _score += score;
      if (scoreText != null) {
         scoreText.text = $"Score:{_score.ToString()}";
      }
   }

   public int ReturnCurrentScore() {
      return _score;
   }
}