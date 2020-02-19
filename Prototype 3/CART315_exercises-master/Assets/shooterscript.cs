using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterscript : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    public int health = 100;

    public Rigidbody doggo;
    public Rigidbody trigger;
    private IEnumerator shrinkray;
    float freezetime = 0;
    bool frozen = false;
    GameObject shrunkDoggo;

    public int killCount =0;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (frozen && Time.time > freezetime)
        {
            frozen = false;
           // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position+new Vector3(0,1f,0), transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
    public void updateUIText(string input)
    {
        GameObject.Find("uitext").GetComponent<UnityEngine.UI.Text>().text = input;
        CancelInvoke();
        Invoke("resetUIText", 3);
    }

    //  public void resetUIText()
    //  {
    //      GameObject.Find("uitext").GetComponent<UnityEngine.UI.Text>().text = "";
    //  }


    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.tag == "levelup")
            {
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                frozen = true;
                freezetime = Time.time + 0.1f;
                GameObject currentDoggo = GameObject.FindGameObjectWithTag("doggo");
                shrunkDoggo = currentDoggo;

                Destroy(collision.gameObject);
                currentDoggo.GetComponent<Rigidbody>().useGravity = true;
                currentDoggo.GetComponent<Rigidbody>().mass = 1;
                //currentDoggo.GetComponent<Rigidbody>().isKinematic = false;
                //currentDoggo.transform.localScale = new Vector3 (1,1,1);

                Rigidbody instantiatedDoggo = Instantiate(doggo, currentDoggo.transform.position + new Vector3(0, -80f, 0), currentDoggo.transform.rotation) as Rigidbody;
                instantiatedDoggo.transform.localScale = new Vector3(15, 15, 15);
                instantiatedDoggo.GetComponent<Rigidbody>().isKinematic = true;


                currentDoggo.GetComponent<shrinkscript>().shrinking = true;
                currentDoggo.tag = "Untagged";

            }
        }
    }

   

}

//https://forum.unity.com/threads/gun-shooting-script-c.222057/
