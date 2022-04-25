using System.Collections.Generic;
using _Code.Color;
using _Code.Enemies;
using _Code.Player;
using UnityEngine;

namespace _Code.Pool {
    
    public class EnemyType {
        public List<Enemy> Enemies = new List<Enemy>();
        public EColor EColor = default;
    }
    
    
    public static class PoolExtentions
    {
        public static void SpawnAndStore<T>(this T component, List<T> list, int count, Transform _transform) where T : Component
        {
            if (component == null || list == null || list.Contains(component)) return;

            for (int i = 0; i < count; i++)
            {
                var a = GameObject.Instantiate(component, _transform);
                a.gameObject.SetActive(false);
                list.Add(a);
            }
        }
        public static Component GetFromStore<T>(this List<T> list, Transform _transform, Vector3 _position, Transform defaultTransform) where T : Component
        {
            if (list.Count <= 3)
            {
                list[0].SpawnAndStore(list, 20, defaultTransform);
            }

            int placeInList = list.Count - 1;
            Component a = list[placeInList];
            list.RemoveAt(placeInList);

            a.transform.position = _position;
            a.gameObject.SetActive(true);
            return a;
        }

        public static void ReturnToStore<T>(this T component, List<T> list, Transform defaultTransform) where T : Component
        {
            // Debug.Log("Return to pool" + component.gameObject.name);
            component.gameObject.SetActive(false);
            component.transform.parent = defaultTransform;
            component.transform.localPosition = Vector3.zero;
            component.transform.localRotation = Quaternion.identity;
  
            list.Add(component);
        }

    }
    
    public class Pool : MonoBehaviour
    {
        public static Pool Instance { get; private set; }
        
        [SerializeField]
        private List<Enemy> poolEnemies = new List<Enemy>();
        [SerializeField]
        private int particleCount = 700;
        
        private void Awake()
        {
            Instance = this;

        }
    }
}
