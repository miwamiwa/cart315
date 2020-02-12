using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhandler : MonoBehaviour
{

    public Rigidbody projectile;
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
        if (Time.time>nextShot)
        {
            

            Vector3 distToPlayer = GameObject.Find("ThirdPersonController").transform.position - gameObject.transform.position;
            distToPlayer.y = 0;
            Vector3 projectileVelocity = distToPlayer.normalized * speed;

            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position + new Vector3(0, 0f, 0)+projectileVelocity, transform.rotation) as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(projectileVelocity);
            nextShot = Time.time + shotInterval;
        }
    }
}
