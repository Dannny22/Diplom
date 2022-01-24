using UnityEngine;
using System.Collections;

public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; 

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();
    } 
    void OnTriggerEnter(Collider other)
    {
            if (MP.ObjectTag == gameObject.tag)
            {
                MP.MissionObjects = true; 
                Destroy(gameObject); 
            }
    }
}
