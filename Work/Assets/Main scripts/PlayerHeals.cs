using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeals : MonoBehaviour
{
    public Image UIhp;
    public float HP = 1f;
    public GameObject Ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UIhp.fillAmount = HP;

        if (HP <= 0)
        {
            //gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().SetTrigger("dead");
            //Instantiate(Ragdoll, transform.position, transform.rotation);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySword" & Enemy.AttackEnemy == true)
        {
            gameObject.GetComponent<Animator>().SetTrigger("damage");
            HP = HP - 0.1f;
        }
    }
}
