using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class Enemy : MonoBehaviour
{

    //public GameObject Player;
    //public float dist;
    //NavMeshAgent nav;
    //public float Radius = 15;
    public float HP = 100;
    public GameObject Ragdoll;
    public Image UIHP;
    public Text UIHpText;
    public Text FireTimeUI;
    public Image FireUI;
    public Text StunTimeUI;
    public Image StunIU;
    public float BurnTime = 0f;
    public float StunTime = 0f;
    //PlayerControll playercontroll = new PlayerControll();
    //public Animator anim;
    public static bool Attack;
    public static bool AttackEnemy;

    public bool isSuperCombo;
    [SerializeField] private float maxTimeBetweenHits = 1;
    [SerializeField] private int hitsUntilSuperCombo = 5;
    [SerializeField] private float powerUpDuration = 5;
    private int hitCounter;
    private float lastHitTime;
    private float powerUpResetTimer;


    // Start is called before the first frame update
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
    }


    void DiactivetAttack()
    {
        AttackEnemy = false;
    }
    public void AddHit()
    {
        if (Time.time - lastHitTime < maxTimeBetweenHits)
        {
            hitCounter++;
            if (hitCounter >= hitsUntilSuperCombo)
            {
                isSuperCombo = true;
                powerUpResetTimer = powerUpDuration;
            }
        }
        else
        {
            hitCounter = 1;
        }
        lastHitTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        UIHpText.text = "" + HP;
        UIHP.fillAmount = HP / 100;
        
        //Player = GameObject.FindGameObjectWithTag("Player");
        //dist = Vector3.Distance(Player.transform.position, transform.position);

        //if (dist > Radius)
        //{
        //    //anim.SetBool("AttackEnemy", false);
        //    nav.speed = 2;
        //    gameObject.GetComponent<Animator>().SetTrigger("walk");
        //    gameObject.GetComponent<EnemyPatrol>().enabled = true;
        //    gameObject.GetComponent<Animator>().SetBool("run", false);
        //}

        //if (dist < Radius && dist > 1.5f)
        //{

        //    nav.speed = 5;
        //    gameObject.GetComponent<EnemyPatrol>().enabled = false;
        //    gameObject.GetComponent<Animator>().SetBool("run", true);
        //    nav.enabled = true;
        //    nav.SetDestination(Player.transform.position);
        //}
        //if (dist < 1f)
        //{
        //    gameObject.GetComponent<Animator>().SetTrigger("attack");
        //    nav.enabled = false;
        //    AttackEnemy = true;
        //    Invoke("DiactivetAttack", 1f);

        //}
        if (isSuperCombo)
        {
            powerUpResetTimer -= Time.deltaTime;
            if (powerUpResetTimer <= 0)
            {
                isSuperCombo = false;
                hitCounter = 0;
            }
        }
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(Ragdoll, transform.position, transform.rotation);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSword" & Attack == true & isSuperCombo == true)
        {
            AddHit();
            HP = HP - 25f;
        }
        else if (other.tag == "PlayerSword" & Attack == true)
        {
            AddHit();
            HP = HP - 5f;
        }

        if (other.tag == "Skill1")
        {
            BurnTime = 10f;
            HP = HP - 20f;
            StartCoroutine(BurnDamage());

        }
        if (BurnTime <= 0f)
        {
            FireTimeUI.gameObject.SetActive(false);
            FireUI.gameObject.SetActive(false);
        }

        if (other.tag == "Skill2")
        {
            StunTime = 5f;
            StartCoroutine(Stunning());
            gameObject.GetComponent<Animator>().SetTrigger("stun");
            
            HP = HP - 20f;
            
        }
        if (StunTime <= 0f)
        {
            StunIU.gameObject.SetActive(false);
            StunTimeUI.gameObject.SetActive(false);
            gameObject.GetComponent<EnemyMovement>().enabled = true;
        }

    }

    private IEnumerator Stunning()
    {
        while (StunTime > 0f)
        {
            StunIU.gameObject.SetActive(true);
            StunTimeUI.gameObject.SetActive(true);
            StunTimeUI.text = "" + StunTime;
            StunTime = StunTime - 1f;
            gameObject.GetComponent<EnemyMovement>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator BurnDamage()
    {
        while (BurnTime > 0f)
        {
            FireUI.gameObject.SetActive(true);
            FireTimeUI.gameObject.SetActive(true);
            FireTimeUI.text = "" + BurnTime;
            BurnTime = BurnTime - 1f;
            HP = HP - 5f;
            yield return new WaitForSeconds(1f);
        }
    }
}
    




