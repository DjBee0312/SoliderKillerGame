using System;
using _Code.Color;
using _Code.Player;
using _Code.System;
using UnityEngine;

namespace _Code.Enemies {
    
    public class Enemy : MonoBehaviour {
        public Action killEnemy;

        public EColor color = EColor.Blue;

        [SerializeField]
        private int rewardForKilling = 5;
        [SerializeField]
        private MeshRenderer _meshRenderer;
        
        private void Start() {
            killEnemy += KillThisEnemy;
            SetColor(color);
        }

        public void SetColor(EColor eColor) {
            _meshRenderer.materials[0].color = ColorController.Instance.ReturnColor(eColor);
            Debug.Log("CHANGE COLOR");
        }
        
        private void KillThisEnemy() {
            Score.increaseScore?.Invoke(rewardForKilling);
            gameObject.SetActive(false);
            Debug.Log("ENEMY KILLED!");
        }
    }
}
