using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SkinColor : MonoBehaviour
{
    public Material[] SkinColors;
    Material CurrMat;
    Renderer rend;
    SaveManager savd;

    // Use this for initialization
    void Start()
    {

        rend = this.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void White()
    {
        rend.material = SkinColors[0];
        CurrMat = rend.material;
    }

    public void Brown()
    {
        rend.material = SkinColors[1];
        CurrMat = rend.material;
    }


    public void Yellow()
    {
        rend.material = SkinColors[2];
        CurrMat = rend.material;
    }


    public void black()
    {
        rend.material = SkinColors[3];
        CurrMat = rend.material;
    }
    public void changemenuscene(string scenename)
    {/*
        BinaryFormatter formmater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Cha.racter";
        FileStream stream = new FileStream(path, FileMode.Create);
        List<float[]> posi = new List<float[]>();
        SavedData data = new SavedData(posi);

        formmater.Serialize(stream, data);
        stream.Close();*/

        //savd.saveCharactor();

        Application.LoadLevel(scenename);
    }

}
