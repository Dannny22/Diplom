using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public float dist;
    NavMeshAgent nav;
    public float Radius = 15;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void DiactivetAttack()
    {
        Enemy.AttackEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist > Radius)
        {
            //anim.SetBool("AttackEnemy", false);
            nav.speed = 2;
            gameObject.GetComponent<Animator>().SetTrigger("walk");
            gameObject.GetComponent<EnemyPatrol>().enabled = true;
            gameObject.GetComponent<Animator>().SetBool("run", false);
        }

        if (dist < Radius && dist > 1.5f)
        {

            nav.speed = 5;
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("run", true);
            nav.enabled = true;
            nav.SetDestination(Player.transform.position);
        }
        if (dist < 1f)
        {
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            nav.enabled = false;
            Enemy.AttackEnemy = true;
            Invoke("DiactivetAttack", 1f);

        }
    }
}
