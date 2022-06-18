using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{

    public class DeathScreen : MonoBehaviour
    {
        HealthBar1 healthBar;
        Respawn respawn;
        public GameObject deathScreenUI;
        public bool PlayerDead;
        PlayerStats playerStats;

        // Start is called before the first frame update
        void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            respawn = FindObjectOfType<Respawn>();
            healthBar = FindObjectOfType<HealthBar1>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerStats.currentHealth <= 0)
            {




                if (PlayerDead)
                {
                    Dead();
                }
                else
                {
                    NotDead();
                }
            }


        }

        public void Dead()
        {
            deathScreenUI.SetActive(true);
            PlayerDead = false;
        }

        public void NotDead()
        {
            PlayerDead = true;
        }

        public void Respawn1()
        {
            healthBar.slider.value = playerStats.maxHealth;
            playerStats.currentHealth = 100;
            deathScreenUI.SetActive(false);
            respawn.player.transform.position = respawn.spawnPoint;
            
        }
    }
}
