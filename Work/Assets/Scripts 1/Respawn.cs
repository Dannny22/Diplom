using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{

    public class Respawn : MonoBehaviour
    {
        public GameObject player;

        [SerializeField] List<GameObject> checkPoints;

        public Vector3 spawnPoint;
        public AudioSource checkPointSound;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CheckPoint"))
            {
                checkPointSound.Play();
                spawnPoint = player.transform.position;
            }
        }

    }
}
