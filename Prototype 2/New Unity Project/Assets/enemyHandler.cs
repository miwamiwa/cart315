using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHandler : MonoBehaviour
{
    public float speed = 0.01f;
    public bool blasted = false;
    float blastCooldown = 0;
    float blastSpeed = 100f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position -= (pos - GameObject.Find("player").transform.position).normalized * speed;
    }

    public void getBlasted()
    {
        Destroy(this);
    }
}
