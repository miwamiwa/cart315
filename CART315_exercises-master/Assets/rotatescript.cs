using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class rotatescript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

		this.transform.Rotate(0, 0.1f*Time.deltaTime, 0);

        // instead of multiplying by Time.deltaTime, you can use FixedUpdate() to ensure a smoothe framerate for the update() function
	}
}
