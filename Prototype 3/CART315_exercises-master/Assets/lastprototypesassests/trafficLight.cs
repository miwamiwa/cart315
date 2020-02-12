using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    float nextChange = 0;
    public int lightstate = 0; // red=0, yellow=1, green=2
    float timeToNextChange = 0;
    
    float timingOffset =0;
    float timingMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        timingOffset = gameObject.GetComponentInParent<lightSetHandler>().timeOffset;
        timingMultiplier = gameObject.GetComponentInParent<lightSetHandler>().timeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextChange + timingOffset)
        {
            switch (lightstate)
            {
                case 0:
                    timeToNextChange = 1f;
                    lightstate = 1;
                    
                    break;
                case 1:
                    timeToNextChange = 5f;
                    lightstate = 2;
                    break;
                case 2:
                    timeToNextChange = 3f;
                    lightstate = 0;
                    break;
            }
            //Debug.Log(lightstate);
            
            SwitchToLight(lightstate);
            nextChange = Time.time + timeToNextChange * timingMultiplier;

            //Debug.Log(nextChange);
        }
        
    }

    void SwitchToLight( int targetstate)
    {
        for(int i=0; i<3; i++)
        {
            GameObject thislight = gameObject.transform.GetChild(2-i).gameObject;

            if (i == targetstate)
            {
                thislight.GetComponent<Light>().intensity = 100f;
            }
            else
            {
                thislight.GetComponent<Light>().intensity = 0f;
            }
            
        }
        
    }

    
}
