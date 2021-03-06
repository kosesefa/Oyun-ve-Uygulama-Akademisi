using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    [SerializeField] GameObject saved;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + "Save.atonal");
        SaveManagement save = new SaveManagement();
        save.Level = SceneManager.GetActiveScene().buildIndex;
        binary.Serialize(file, save);
        file.Close();
       // anim.SetBool("saved", true);

    }
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/" + "Save.atonal"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + "Save.atonal", FileMode.Open);
            SaveManagement save = (SaveManagement)binaryFormatter.Deserialize(file);
            SceneManager.LoadScene(save.Level);
        }
        else
        {
        }
    }
}
[Serializable]
public class SaveManagement
{
    public int Level;

}