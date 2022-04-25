using System;
using _Code.Color;
using _Code.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.System {
    public class PlayerInfo : MonoBehaviour {
       [SerializeField]
       private Image infoColor = null;

       private void Awake() {
          Controller.switchColor += ChangeColor;
       }

       private void ChangeColor(EColor eColor) {
            infoColor.color = ColorController.Instance.ReturnColor(eColor);
       }
    }
}
