using System.Collections.Generic;
using UnityEngine;

public class EnemyType {
   public List<Enemy> pooledEnemies = new List<Enemy>();
}


public static class PoolExtentions {
   public static void SpawnAndStore<T>(this T component, List<T> list, int count, Transform _transform)
      where T : Component {
      if (component == null || list == null || list.Contains(component)) return;

      for (int i = 0; i < count; i++) {
         var a = GameObject.Instantiate(component, _transform);
         a.gameObject.SetActive(false);
         list.Add(a);
      }
   }

   public static Component GetFromStore<T>(this List<T> list,
                                           Transform _transform,
                                           Vector3 _position,
                                           Transform defaultTransform) where T : Component {
      if (list.Count <= 3) {
         list[0].SpawnAndStore(list, 20, defaultTransform);
      }

      int placeInList = list.Count - 1;
      Component a = list[placeInList];
      list.RemoveAt(placeInList);

      a.transform.position = _position;
      a.gameObject.SetActive(true);
      return a;
   }

   public static void ReturnToStore<T>(this T component, List<T> list, Transform defaultTransform) where T : Component {
      // Debug.Log("Return to pool" + component.gameObject.name);
      component.gameObject.SetActive(false);
      component.transform.parent = defaultTransform;
      component.transform.localPosition = Vector3.zero;
      component.transform.localRotation = Quaternion.identity;

      list.Add(component);
   }
}

public class Pool : MonoBehaviour {
   public static Pool Instance { get; private set; }

   [SerializeField]
   private Enemy enemy = null;

   [SerializeField]
   private List<EnemyType> poolEnemies = new List<EnemyType>();

   [SerializeField]
   private int enemyCount = 70;

   private void Awake() {
      Instance = this;
      CreateEnemyPool(enemy, enemyCount);
   }

   private void CreateEnemyPool(Enemy enemy, int poolSize) {
      EnemyType enemyType = new EnemyType();
      enemy.SpawnAndStore(enemyType.pooledEnemies, poolSize, transform);
      poolEnemies.Add(enemyType);
   }

   public Enemy GetEnemy(Vector3 _position, Transform _parrent, EColor eColor) {
      foreach (EnemyType enemyType in poolEnemies) {
         Enemy enemy = (Enemy) enemyType.pooledEnemies.GetFromStore(_parrent, _position, transform);
         enemy.gameObject.SetActive(true);
         enemy.ClearRigidbody();
         enemy.color = eColor;
         enemy.SetColor(eColor);
         return enemy;
      }

      return null;
   }

   public void ReturnEnemy(Enemy enemy) {
      foreach (EnemyType enemyType in poolEnemies) {
         enemy.gameObject.SetActive(false);
         enemy.ReturnToStore(enemyType.pooledEnemies, transform);
         break;
      }
   }
}