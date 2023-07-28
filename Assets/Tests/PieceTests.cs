using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PieceTests
{
    [Test]
    public void PieceTestsSimplePasses()
    {
        
    }

    [UnityTest]
    public IEnumerator TestSpawner()
    {
        var spawnerObject = Object.Instantiate(new GameObject());
        spawnerObject.AddComponent(typeof(PieceSpawner));

        //Assert.AreEqual()

        yield return null;
    }

}
