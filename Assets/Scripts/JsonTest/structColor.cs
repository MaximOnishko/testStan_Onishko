using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public struct Config 
{
    //{user: {color: [r, g, b]}, enemy: {color1: [r, g, b], color2: [r, g, b]}}
   public User user;
   public EnemyCol enemy;

    public override string ToString()
    {
        return ($"user{user.color},enemy{enemy.color1},{enemy.color2}");
    }
}

