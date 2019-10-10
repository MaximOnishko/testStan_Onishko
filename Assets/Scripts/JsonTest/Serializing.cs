using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class Serializing : MonoBehaviour
{
    Config config;

    void Start()
    {
        config = new Config
        {
            user = new User(),
            enemy = new EnemyCol()
        };

        //config.user = new User();
        config.user.color = new Color(0, 0, 0);

        //config.enemy = new Enemy();
        config.enemy.color1 = new Color(50, 50, 50);
        config.enemy.color2 = new Color(70, 70, 70);

        SaveToJson();
    }

    private void SaveToJson()
    {
        string playerToJason = JsonUtility.ToJson(config,true);
        Debug.Log(playerToJason);
    }
}
