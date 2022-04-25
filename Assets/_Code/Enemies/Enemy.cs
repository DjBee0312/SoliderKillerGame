using System;
using _Code.Color;
using _Code.Player;
using UnityEngine;

namespace _Code.Enemies {
    
    public class Enemy : MonoBehaviour {
        public Action killEnemy;

        public EColor color = EColor.Blue;

        [SerializeField]
        private MeshRenderer _meshRenderer;


        private void Start() {
            killEnemy += KillThisEnemy;
            _meshRenderer.materials[0].color = ColorController.Instance.ReturnColor(color);
        }

        private void KillThisEnemy() {
            Debug.Log("ENEMY KILLED!");
        }
    }
}
