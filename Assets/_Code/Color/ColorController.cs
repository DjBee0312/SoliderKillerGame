using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour {
   public static ColorController Instance;

   [SerializeField]
   private ColorSystem _colorSystem = null;

   private void Awake() { Instance = this; }

   public Color ReturnColor(EColor eColor) {
      foreach (ColorData colorData in _colorSystem.ColorDatas) {
         if (colorData.ColorName == eColor) {
            return colorData.Color;
         }
      }

      return Color.black;
   }
}