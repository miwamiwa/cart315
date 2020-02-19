using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemies : MonoBehaviour
{

    public Rigidbody enemy;
    public float speed = 20;
    float nextShot = 0;
    public float shotInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShot)
        {
            
            GameObject[] Locations = GameObject.FindGameObjectsWithTag("spawnlocation");

            Vector3 spawnPoint = Locations[Random.Range(0, Locations.Length)].transform.position;
            Rigidbody newEnemy = Instantiate(enemy, spawnPoint, transform.rotation);
            if (GameObject.Find("ThirdPersonController").GetComponent<shooterscript>().killCount % 5 == 0)
            {
                newEnemy.GetComponent<enemyhandler>().isTargetCarrier = true;
            }
            nextShot = Time.time + shotInterval;
        }
    }

    

}
