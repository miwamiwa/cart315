using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinHandler : MonoBehaviour
{
    public float rotate_speed = 0.1f;
    GameObject the_other_object;
    GameObject the_other_object2;
    GameObject the_other_object3;
    // Start is called before the first frame update
    void Start()
    {
        the_other_object = GameObject.Find("ColliderFront");
        the_other_object2 = GameObject.Find("ColliderBody");
        the_other_object3 = GameObject.Find("ColliderBottom");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        this.transform.Rotate(0, 0, rotate_speed);
        // is using Update() instead of FixedUpdate() consider using Time.deltaTime
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == the_other_object|| other.gameObject == the_other_object2|| other.gameObject == the_other_object3)
        {
            GameObject.Find("Car").GetComponent<coolPlayerControls>().score++;
            Destroy(gameObject);
        }
    }
}
