    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class projectilehandler : MonoBehaviour
    {

    public string target = "";
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

            if(collision.gameObject.name == target)
            {
                Destroy(gameObject);
            if (target != "ThirdPersonController") Destroy(collision.gameObject);
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
