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
        StartCoroutine(LookAround());
        i = Random.Range(0, targets.Count);
    }

    private IEnumerator LookAround()
    {
        while (nav.transform.position == nav.pathEndPosition)
        {
            gameObject.GetComponent<Animator>().SetTrigger("LookAround");
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        if (nav.transform.position == nav.pathEndPosition)
        {
            TargetUpdate();
            gameObject.GetComponent<Animator>().SetTrigger("walk");
        }
        nav.SetDestination(targets[i].position);
    }
}
