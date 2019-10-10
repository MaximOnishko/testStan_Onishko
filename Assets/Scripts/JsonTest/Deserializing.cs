using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Deserializing : MonoBehaviour
{
    Config[] config;


    void Start()
    {
        deserialize();
        //config[0].ToString();
    }
    void deserialize()
    {
        string path = Application.dataPath + "/Resources/Config.txt";
        StreamReader st = new StreamReader(path);
        //var sw = new StreamWriter(Application.dataPath + "/Resources/test.txt", false, Encoding.UTF8);
        //Overwrite the values in the existing class instance "playerInstance". Less memory Allocation

        JsonUtility.FromJsonOverwrite(st.ReadToEnd(), config);
        Debug.Log(config[0].user.color);

        //JsonHelper.FromJson<Config>();
        //config = JsonHelper.FromJson<Config>();
    }
}
