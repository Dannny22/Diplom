using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLootAt : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public float range;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(Enemy.transform.position, transform.position);

        if(Input.GetMouseButton(1) & range <= 15)
        {
            cam1.active = false;
            cam2.active = true;
        }
            
    }
}
