using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem
{
    public static void SavePlayer(List<float[]> player)
    {
        BinaryFormatter formmater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/FLB.House";
        FileStream stream = new FileStream(path, FileMode.Create);
        List<float[]> posi = new List<float[]>();
        SavedData data = new SavedData(posi);

        formmater.Serialize(stream, data);
        stream.Close();
    }
    public static SavedData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/FLB.House";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("没有存档啊" + path);
            return null;
        }

    }
}
