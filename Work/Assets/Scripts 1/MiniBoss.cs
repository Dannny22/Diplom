using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    //public GameObject Player;
    //public float dist;
    //NavMeshAgent nav;
    //public float Radius = 15;
    public float HP = 100;
    //public GameObject Ragdoll;
    //public Image UIHP;
    //public Text UIHpText;
    //public Text FireTimeUI;
    //public Image FireUI;
    //public Text StunTimeUI;
    //public Image StunIU;
    public float BurnTime = 0f;
    public float StunTime = 0f;
    //PlayerControll playercontroll = new PlayerControll();
    public Animator anim;
    public static bool Attack;
    public static bool AttackEnemy;
    //EnemyMovement enemyMovement;

    //public bool isSuperCombo;
    //[SerializeField] private float maxTimeBetweenHits = 1;
    //[SerializeField] private int hitsUntilSuperCombo = 5;
    //[SerializeField] private float powerUpDuration = 5;
    //private int hitCounter;
    //private float lastHitTime;
    //private float powerUpResetTimer;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //nav = GetComponent<NavMeshAgent>();
        //enemyMovement = GetComponent<EnemyMovement>();
    }


    void DiactivetAttack()
    {
        AttackEnemy = false;
    }
    //public void AddHit()
    //{
    //    if (Time.time - lastHitTime < maxTimeBetweenHits)
    //    {
    //        hitCounter++;
    //        if (hitCounter >= hitsUntilSuperCombo)
    //        {
    //            isSuperCombo = true;
    //            powerUpResetTimer = powerUpDuration;
    //        }
    //    }
    //    else
    //    {
    //        hitCounter = 1;
    //    }
    //    lastHitTime = Time.time;
    //}

    public void Update()
    {
        //UIHpText.text = "" + HP;
        //UIHP.fillAmount = HP / 100;


        //if (isSuperCombo)
        //{
        //    powerUpResetTimer -= Time.deltaTime;
        //    if (powerUpResetTimer <= 0)
        //    {
        //        isSuperCombo = false;
        //        hitCounter = 0;
        //    }
        //}
        if (HP <= 0)
        {
            gameObject.GetComponent<MiniBossMovement>().enabled = false;
            anim.SetBool("Dead", true);
            //enemyMovement.battleMusic.SetActive(false);
            //enemyMovement.backMusic.SetActive(true);
            //gameObject.SetActive(false);
            //gameObject.GetComponent<Animator>().SetBool("Dead", true);
            //Instantiate(Ragdoll, transform.position, transform.rotation);
        }

        if (StunTime <= 0f)
        {
            //StunIU.gameObject.SetActive(false);
            //StunTimeUI.gameObject.SetActive(false);

            gameObject.GetComponent<MiniBossMovement>().enabled = true;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSword" & Attack == true /*& isSuperCombo == true*/)
        {
            anim.SetTrigger("Hit");
            //AddHit();
            HP = HP - 25f;
        }
        else if (other.tag == "PlayerSword" & Attack == true)
        {
            anim.SetTrigger("Hit");
            //AddHit();
            HP = HP - 5f;
        }

        if (other.tag == "Skill1")
        {
            BurnTime = 10f;
            HP = HP - 20f;
            StartCoroutine(BurnDamage());
            anim.SetTrigger("Hit");

        }
        //if (BurnTime <= 0f)
        //{
        //    FireTimeUI.gameObject.SetActive(false);
        //    FireUI.gameObject.SetActive(false);
        //}

        if (other.tag == "Skill2")
        {
            StunTime = 5f;
            StartCoroutine(Stunning());
            anim.SetTrigger("Hit");
            anim.SetTrigger("stun");
            HP = HP - 20f;
        }

    }

    private IEnumerator Stunning()
    {
        while (StunTime > 0f)
        {
            //StunIU.gameObject.SetActive(true);
            //StunTimeUI.gameObject.SetActive(true);
            //StunTimeUI.text = "" + StunTime;
            StunTime = StunTime - 1f;

            gameObject.GetComponent<MiniBossMovement>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator BurnDamage()
    {
        while (BurnTime > 0f)
        {
            //FireUI.gameObject.SetActive(true);
            //FireTimeUI.gameObject.SetActive(true);
            //FireTimeUI.text = "" + BurnTime;
            BurnTime = BurnTime - 1f;
            HP = HP - 5f;
            yield return new WaitForSeconds(1f);
        }
    }
}
