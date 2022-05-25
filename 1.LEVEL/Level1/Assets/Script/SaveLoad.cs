using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + "Save.atonal");
        SaveManagement save = new SaveManagement();
        save.Level= SceneManager.GetActiveScene().buildIndex;
        binary.Serialize(file,save);
        file.Close();
    }
    public void Load()
    {

    }
}
public class SaveManagement
{
    public int Level;

}
