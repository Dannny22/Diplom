using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoCache
{
    public float time = 1f; 

    public override void OnTick()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    } 
}
