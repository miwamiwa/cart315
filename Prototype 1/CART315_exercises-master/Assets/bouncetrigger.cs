using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class bouncetrigger : MonoBehaviour
{
    public GameObject the_other_object;
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
		//other.transform.Translate(0, 0.2f, 0);
		//other.GetComponent<Rigidbody>().AddForce(0, 500.0f, 0);
		if (other.gameObject == the_other_object)
		{
			other.GetComponent<AudioSource>().Play();
		}
		
	}

    private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == the_other_object)
		{
			other.GetComponent<Rigidbody>().AddForce(0, 3000.0f * Time.deltaTime, 0);
		}

	}
}
