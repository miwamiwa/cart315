using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSetHandler : MonoBehaviour
{
    public float timeMultiplier = 1f;
    public float timeOffset = 0f;
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
        // Debug.Log("collision!");
        if (other.gameObject == the_other_object)
        {

            int lightstate = gameObject.transform.GetChild(0).GetComponent<trafficLight>().lightstate;
            Vector3 copPos = GameObject.FindWithTag("cop").transform.position;
            Vector3 thisPos = gameObject.transform.position;
            int detectRange = GameObject.FindWithTag("cop").GetComponent<copperBehavior>().detectRange;
            bool copInRange = false;
            float dist = (copPos - thisPos).magnitude;
            if (dist < detectRange)
            {
                //Debug.Log("copper caught you");
                copInRange = true;
            }
            switch (2 - lightstate)
            {
                case 0: //Debug.Log("hit a red light");
                    if (copInRange)
                    {
                        updateUIText("you're caught!");
                    }
                    else
                    {
                        updateUIText("red light");
                    }
                    
                    break;
                case 1: //Debug.Log("hit a yellow light");
                    updateUIText("yellow light");
                    break;
                case 2: //Debug.Log("hit a green light");
                    updateUIText("green light");
                    break;
            }

            
        }

    }

    void updateUIText(string input)
    {
        GameObject.FindWithTag("uitext").GetComponent<UnityEngine.UI.Text>().text = input;
        CancelInvoke();
        Invoke("resetUIText", 3);
    }

    void resetUIText()
    {
        GameObject.FindWithTag("uitext").GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
