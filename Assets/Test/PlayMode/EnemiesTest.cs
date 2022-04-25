using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestsOfScripts
{
    
    [UnityTest]
    public IEnumerator ScoreIncreasingTestWithEnumeratorPasses() {
        GameObject go = new GameObject();
        Score sc = go.AddComponent<Score>();
        yield return new WaitForSeconds(0.1f);
        Score.increaseScore?.Invoke(10);
        yield return null;
        Assert.AreEqual(10, sc.ReturnCurrentScore());
    }
    
    [UnityTest]
    public IEnumerator PlayerColorChangeTestWithEnumeratorPasses() {
        GameObject go = new GameObject();
        Controller controller = go.AddComponent<Controller>();
        Controller.switchColor?.Invoke(EColor.Red);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(EColor.Red, controller.ReturnCurrentColor());
    }
    
    [UnityTest]
    public IEnumerator EnemyKillingTestWithEnumeratorPasses() {
        GameObject go = new GameObject();
        Enemy enemy = go.AddComponent<Enemy>();
        yield return new WaitForSeconds(0.1f);
        enemy.killEnemy?.Invoke();
        yield return new WaitForSeconds(3.5f);
        Assert.AreEqual(false, enemy.gameObject.activeSelf);
    }
    
}
