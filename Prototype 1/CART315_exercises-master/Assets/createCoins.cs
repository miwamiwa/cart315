using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCoins : MonoBehaviour
{
    public GameObject createCoin;
    public int coinCount = 100;
    public float distFromGround = 1;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = GameObject.Find("CONCRETE FLOOR").GetComponent<MeshCollider>().bounds.size;
        Vector3 pos = GameObject.Find("CONCRETE FLOOR").transform.position;

        for (int i=0; i<coinCount; i++)
        {
            float x = Random.Range(pos.x, pos.x+size.x);
            float z = Random.Range(pos.z, pos.z+size.z);
            GameObject.Instantiate(createCoin, new Vector3(x, pos.y+distFromGround, z), Quaternion.Euler(90, 0, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
