using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class rotatescript : MonoBehaviour
{
	public float rotate_speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetButton("Fire1"))
		{
			this.transform.Rotate(0, rotate_speed, 0);
		}
		

        // is using Update() instead of FixedUpdate() consider using Time.deltaTime
	}
}
