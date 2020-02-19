using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkscript : MonoBehaviour
{

    public bool shrinking = false;
    bool prevstate = false;
    Component rb;
    // Start is called before the first frame update
    void Start()
    {
     //   rb = GetComponent<Rigidbody>();

        GetComponent<MeshCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (shrinking)
        {
            if (!prevstate)
            {
                GetComponent<MeshCollider>().enabled = false;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent< Rigidbody > ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
            Vector3 newSize = gameObject.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
            if (newSize.magnitude > 1)
            {
                gameObject.transform.localScale = newSize;
               gameObject.transform.position -= new Vector3(0, 0f, +0.2f);
                
            }
            else
            {
                shrinking = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
              //  Debug.Log("stahp");
            }
        }
        prevstate = shrinking;
    }
}
