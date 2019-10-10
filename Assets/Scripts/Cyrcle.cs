using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cyrcle :MonoBehaviour
{

    public  Vector3 size { get; set; }

    public Vector3 increaseSize(Vector3 size, float intcrease)
    {
        return size * intcrease;
    }

    public virtual void assignSize(Vector3 currentSize)
    {
        transform.localScale = currentSize;
    }
}
