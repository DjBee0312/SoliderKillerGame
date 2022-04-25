using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour {
   public Action killEnemy;

   public EColor color = EColor.Blue;

   [SerializeField]
   private int rewardForKilling = 5;

   [SerializeField]
   private Rigidbody _rigidbody = null;

   [SerializeField]
   private MeshRenderer _meshRenderer;

   private bool _isKilled = false;
   private float _timer = 3f;

   private void Start() {
      killEnemy += KillThisEnemy;
      SetColor(color);
   }

   private void Update() {
      if (_isKilled) {
         if (_timer > 0f) {
            _timer -= Time.deltaTime;
         } else {
            _isKilled = false;
            _timer = 3f;
            if (Pool.Instance) {
               Pool.Instance.ReturnEnemy(this);
            }
            gameObject.SetActive(false);
         }
      }
   }

   public void SetColor(EColor eColor) {
      if (ColorController.Instance) {
         _meshRenderer.materials[0].color = ColorController.Instance.ReturnColor(eColor);
      }
   }

   private void KillThisEnemy() {
      if (_isKilled) return;
      _isKilled = true;
      Score.increaseScore?.Invoke(rewardForKilling);
      if (_rigidbody != null) {
         _rigidbody.AddForce(Vector3.forward * 25f);
         _rigidbody.AddTorque((Vector3.up * Random.Range(-50f, 50f) + (Vector3.left * Random.Range(-50f, 50f)) * 105f));
      }
   }

   public void ClearRigidbody() {
      _rigidbody.angularVelocity = Vector3.zero;
      _rigidbody.interpolation = 0f;
      _rigidbody.velocity = Vector3.zero;
      _rigidbody.ResetInertiaTensor();
   }
}