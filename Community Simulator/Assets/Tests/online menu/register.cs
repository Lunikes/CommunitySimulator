using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class register
    {
        // A Test behaves as an ordinary method
        [Test]
        public void registerSimplePasses()
        {
            string userNameD = "test";
            if (!System.IO.File.Exists(@"C:/Document/" + userNameD + ".txt")) //The save location can be change
            {
                
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator registerWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
