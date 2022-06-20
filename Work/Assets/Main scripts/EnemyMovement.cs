using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    public CharacterController controller;
    public GameObject Player;
    public float dist;
    NavMeshAgent nav;
    public float Radius = 15;
    //public GameObject battleMusic;
    //public GameObject backMusic;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void DiactivetAttack()
    {
        Enemy.AttackEnemy = false;
    }

    public void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist > Radius)
        {
            //battleMusic.SetActive(false);
            //backMusic.SetActive(true);
            nav.speed = 2;
            anim.SetTrigger("walk");
            gameObject.GetComponent<EnemyPatrol>().enabled = true;
            anim.SetBool("run", false);
        }

        if (dist < Radius && dist > 1.5f)
        {
            //battleMusic.SetActive(true);
            //backMusic.SetActive(false);
            nav.speed = 5;
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            anim.SetBool("run", true);
            nav.enabled = true;
            nav.SetDestination(Player.transform.position);
        }

        if (dist < 1f)
        {
            anim.SetTrigger("attack");
            anim.SetBool("run", false);
            nav.enabled = false;
            Enemy.AttackEnemy = true;
            Invoke("DiactivetAttack", 1f);
        }
    }
     
}
