using System;
using UnityEngine;

public class Controller : MonoBehaviour {
   public static Action<EColor> switchColor;

   [SerializeField]
   private EColor _color = EColor.Red;

   private void Start() {
      switchColor += ChangeColor;
      switchColor?.Invoke(EColor.Red);
   }

   private void Update() {
      if (Input.GetMouseButtonDown(0)) {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit)) {
            //Select stage    
            if (hit.transform.TryGetComponent(out Enemy enemy)) {
               if (enemy.color == _color) {
                  enemy.killEnemy?.Invoke();
               }
            }
         }
      }
   }

   private void ChangeColor(EColor newColor) { _color = newColor; }

   public EColor ReturnCurrentColor() {
      return _color;
   }
}