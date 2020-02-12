using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterscript : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    public int health = 100;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


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
    
}

//https://forum.unity.com/threads/gun-shooting-script-c.222057/
