using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class colormanipulation
    {
        // A Test behaves as an ordinary method
        [Test]
        public void colormanipulationSimplePasses()
        {
            GameObject go = new GameObject("MyGameObject");
            go.AddComponent<UnityEngine.MeshRenderer>();
            Renderer rend = go.GetComponent<Renderer>();
            rend.material.SetColor("_Color", Color.green);
            var answer = rend.material.GetColor("_Color");
            var expected = Color.blue;
            Assert.AreEqual(expected, answer);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator colormanipulationWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
