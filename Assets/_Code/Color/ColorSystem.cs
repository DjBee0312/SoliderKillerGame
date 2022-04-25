using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Code.Color {
    public enum EColor {
        Red,
        Green,
        Blue
    }
    
    [Serializable]
    public class ColorData
    {
        public EColor ColorName = EColor.Red;
        public UnityEngine.Color Color = UnityEngine.Color.red;
    }
    
    [CreateAssetMenu(fileName = "COLORSettings", menuName = "Create Color settings")]
    public class ColorSystem : ScriptableObject
    {
        public List<ColorData> ColorDatas = new List<ColorData>();
    }
}
