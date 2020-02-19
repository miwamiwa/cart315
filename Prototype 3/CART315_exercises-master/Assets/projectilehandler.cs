    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class projectilehandler : MonoBehaviour
    {

    public string target = "";
    public Rigidbody spherethingy;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision collision)
        {

            if(collision.gameObject.tag=="enemy")
            {
                Destroy(gameObject);
            if (target != "ThirdPersonController")
            {
                if (collision.gameObject.GetComponent<enemyhandler>().isTargetCarrier)
                {
                    Vector3 spawnPoint = collision.gameObject.transform.position;
                    Rigidbody newTarget = Instantiate(spherethingy, spawnPoint, collision.gameObject.transform.rotation);
                }
                Destroy(collision.gameObject);
                GameObject.Find("ThirdPersonController").GetComponent<shooterscript>().killCount++;
            }
            else
            {

                GameObject.Find("ThirdPersonController").GetComponent<shooterscript>().health -= 10;
                GameObject.Find("ThirdPersonController").GetComponent<shooterscript>().updateUIText(
                     GameObject.Find("ThirdPersonController").GetComponent<shooterscript>().health.ToString()
                    );
            }
            }
        }
    }
