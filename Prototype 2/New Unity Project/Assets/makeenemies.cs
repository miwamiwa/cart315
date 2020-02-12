using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeenemies : MonoBehaviour
{

    float timeToSpawn = 0;
    public GameObject enemyprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            GameObject enemy;
            enemy = Instantiate(enemyprefab, new Vector3(Random.RandomRange(0, 10), 1.4f, Random.RandomRange(0, 10)), Quaternion.identity);
            timeToSpawn = Time.time + 3f;
        }
    }
}
