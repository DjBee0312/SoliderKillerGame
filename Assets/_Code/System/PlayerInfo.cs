using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {
   [SerializeField]
   private Image infoColor = null;

   private void Awake() { Controller.switchColor += ChangeColor; }

   private void ChangeColor(EColor eColor) { infoColor.color = ColorController.Instance.ReturnColor(eColor); }
}