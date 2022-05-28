using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeals : MonoBehaviour
{
    public Image UIhp;
    public float HP = 1f; 
    public GameObject Control;
 
    void Update()
    {

        UIhp.fillAmount = HP;

        if (HP <= 0)
        { 
            gameObject.GetComponent<Animator>().SetTrigger("dead");
            gameObject.GetComponent<PlayerLookAt>().enabled = false;
            Control.GetComponent<PlayerHandler>().enabled = false;
            gameObject.GetComponent<PlayerSkills>().enabled = false;
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
