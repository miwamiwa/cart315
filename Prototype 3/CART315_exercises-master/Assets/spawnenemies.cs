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

            Mesh mesh = GameObject.Find("spawnarea").GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            
            int randomPick = Random.RandomRange(0, vertices.Length);
            

            Vector3 v = vertices[randomPick];
            Vector3 spawnPoint = new Vector3(v.x, GameObject.Find("enemy").transform.position.y+50f, v.z);
            Debug.Log(spawnPoint);
            var q = Random.Range(0, vertices.Length);
                spawnPoint = transform.TransformPoint(vertices[q]);
                Instantiate(enemy, spawnPoint, transform.rotation);
            


          //  Rigidbody instantiatedProjectile = Instantiate(enemy, new Vector3, Quaternion.identity) as Rigidbody;

            //instantiatedProjectile.velocity = transform.TransformDirection(projectileVelocity);
            nextShot = Time.time + shotInterval;
        }
    }

    

}
