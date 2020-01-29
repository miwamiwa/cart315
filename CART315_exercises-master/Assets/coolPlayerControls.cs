using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolPlayerControls : MonoBehaviour
{
    public GameObject thecamera;
    public GameObject create;

    bool mousepress = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1)&&mousepress==false)
        {
            mousepress = true;
            RaycastHit hit;
            Ray ray = thecamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            bool hitSomething = Physics.Raycast(ray, out hit, Mathf.Infinity);

            if (hitSomething)
            {
                Debug.Log("hit something~");
                GameObject.Instantiate(create, hit.point + new Vector3(0,2,0), Quaternion.identity);
            }
        }
        else if(!Input.GetMouseButton(1)){
            mousepress = false;
        }
    }
}
