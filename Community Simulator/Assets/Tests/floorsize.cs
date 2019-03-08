using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class floorsize
    {
        // A Test behaves as an ordinary method
        GameObject button1 = new GameObject("buttonTest1");
        GameObject button2 = new GameObject("buttonTest2");
        GameObject button3 = new GameObject("buttonTest3");
        Vector3 position = new Vector3(0, 0, 0);
        [Test]
        public void floorsizeSimplePasses()
        { 
            //Debug.Log(button.name.ToString());
            //Assert.AreEqual(button.name.ToString(),"buttonTest");
            setAct();
            //test for active and deactivating GameObjects
            Assert.AreEqual(button1.activeSelf.ToString(), "True");
            Debug.Log(button1.activeSelf.ToString());
        }

        [Test]
        //gridspawner tester
        public void floorsizeSimplePasses1()
        {
            int length = 12;

            ApplayChange(length, length);
            Assert.AreEqual(position.x.ToString(),"11");
        }
        //test for boject names
        [Test]
        public void floorsizeSimplePasses2()
        {
            Assert.AreEqual(button1.name.ToString(), "buttonTest1");
            Assert.AreEqual(button2.name.ToString(), "buttonTest2");
            Assert.AreEqual(button3.name.ToString(), "buttonTest3");
        }
        //gridspwaner test for z
        [Test]
        public void floorsizeSimplePasses3()
        {
            int length = 12;

            ApplayChange(length, length);
            Assert.AreEqual(position.z.ToString(), "11");
        }

        //gridspwaner test for y
        [Test]
        public void floorsizeSimplePasses4()
        {
            int length = 12;

            ApplayChange(length, length);
            Assert.AreEqual(position.y.ToString(), "0");
        }

        //gridspwaner test for length times width of floor plan
        [Test]
        public void floorsizeSimplePasses5()
        {
            int length = 12;

            ApplayChange(length, length);
            float side = position.z+1;
            float side2 = position.z+1;
            Assert.AreEqual(side*side2, 144.0f);
        }

        [Test]
        //test seting items active
        public void floorsizeSimplePasses_setative()
        {
            setAct();
            Assert.AreEqual(button1.activeSelf.ToString(), "True");
            Debug.Log(button1.activeSelf.ToString());
        }

        [Test]
        //test seting items false
        public void floorsizeSimplePasses_setinactive()
        {
            setActNo();
            Assert.AreEqual(button1.activeSelf.ToString(), "False");
            Debug.Log(button1.activeSelf.ToString());
        }


        void setAct()
        {
            button1.SetActive(true);
        }
        void setActNo()
        {
            button1.SetActive(false);
        }

        void ApplayChange(int xlength,int zlength)
        {
            for (int x = 0; x < xlength; x++)
            {
                for (int z = 0; z < zlength; z++)
                {
                    position = new Vector3(x, 0, z);//Off set the grid a bit so it will round to whole interger by building system so everything will line up to the edge of the cube
                }

            }
        }
    }
}
