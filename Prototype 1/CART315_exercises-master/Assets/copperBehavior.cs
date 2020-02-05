using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copperBehavior : MonoBehaviour
{

    public GameObject[] lights;
    float nextChange = 0f;
    public float changePositionsInterval = 10f;
    int lightsNum = 0;
    public int detectRange = 8;

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("trafficlights");
        lightsNum = lights.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextChange)
        {
            int nextLocation = Random.Range(0, lightsNum);
            gameObject.transform.SetPositionAndRotation(lights[nextLocation].transform.position, Quaternion.identity);
            nextChange = Time.time + changePositionsInterval;
        }
    }
}
