using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    NavMeshAgent nav;
    public List<Transform> targets;
    int i;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public void TargetUpdate()
    {
        i = Random.Range(0, targets.Count);
    }

    void Update()
    {
        if (nav.transform.position == nav.pathEndPosition)
        {
            gameObject.GetComponent<Animator>().SetTrigger("walk");
            TargetUpdate();
        }
        nav.SetDestination(targets[i].position);
    }
}
