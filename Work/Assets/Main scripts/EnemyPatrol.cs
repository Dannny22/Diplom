using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoCache
{
    Animator anim;
    NavMeshAgent nav;
    public List<Transform> targets;
    int i;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    public void TargetUpdate()
    {
        //StartCoroutine(LookAround());
        i = Random.Range(0, targets.Count);
    }

    //private IEnumerator LookAround()
    //{
    //    while (nav.transform.position == nav.pathEndPosition)
    //    {
    //        gameObject.GetComponent<Animator>().SetBool("Walk2", false);
    //        gameObject.GetComponent<Animator>().SetBool("Look", true);
    //        //gameObject.GetComponent<Animator>().SetTrigger("LookAround");
    //        //gameObject.GetComponent<Animator>().SetTrigger("walk");
    //        yield return new WaitForSeconds(1f);
    //    }
    //}
    public override void OnTick()
    {

        if (nav.transform.position == nav.pathEndPosition)
        {
            TargetUpdate();
            //gameObject.GetComponent<Animator>().SetBool("Walk2", true);
            //gameObject.GetComponent<Animator>().SetBool("Look", false);
            anim.SetTrigger("walk");
            // gameObject.GetComponent<Animator>().SetTrigger("LookAround");
        }
        nav.SetDestination(targets[i].position);
    }
     
}
