
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Color {
    public class ColorController : MonoBehaviour {
        public static ColorController Instance;
        [SerializeField]
        private ColorSystem _colorSystem = null;

        private void Awake() {
            Instance = this;
        }

        public UnityEngine.Color ReturnColor(EColor eColor) {
            foreach (ColorData colorData in _colorSystem.ColorDatas) {
                if (colorData.ColorName == eColor) {
                    return colorData.Color;
                }
            }
            return UnityEngine.Color.black;
        }
    }
}
