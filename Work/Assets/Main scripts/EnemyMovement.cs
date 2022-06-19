using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoCache
{
    public CharacterController controller;
    public GameObject Player;
    public float dist;
    NavMeshAgent nav;
    public float Radius = 15;
    public GameObject battleMusic;
    public GameObject backMusic;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void DiactivetAttack()
    {
        Enemy.AttackEnemy = false;
    }

    public override void OnTick()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist > Radius)
        {
            battleMusic.SetActive(false);
            backMusic.SetActive(true);
            nav.speed = 2;
            gameObject.GetComponent<Animator>().SetTrigger("walk");
            gameObject.GetComponent<EnemyPatrol>().enabled = true;
            gameObject.GetComponent<Animator>().SetBool("run", false);
        }

        if (dist < Radius && dist > 1.5f)
        {
            battleMusic.SetActive(true);
            backMusic.SetActive(false);
            nav.speed = 5;
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("run", true);
            nav.enabled = true;
            nav.SetDestination(Player.transform.position);
        }

        if (dist < 2f)
        {
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            nav.enabled = false;
            Enemy.AttackEnemy = true;
            Invoke("DiactivetAttack", 1f);
        }
    }
     
}
