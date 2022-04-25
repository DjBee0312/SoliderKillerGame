using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour {
   [SerializeField]
   private Image _button = null;

   [SerializeField]
   private EColor _eColor = EColor.Red;

   private void Awake() { _button.color = ColorController.Instance.ReturnColor(_eColor); }

   public void OnButtonClick() { Controller.switchColor?.Invoke(_eColor); }
}