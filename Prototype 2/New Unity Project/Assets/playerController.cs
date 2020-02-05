using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float rotate_speed = 3f;
    public float speed = 1.0f;
    public Rigidbody rb;
    GameObject plane;
    GameObject rock;
    GameObject guy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plane = GameObject.Find("plane");
        guy = GameObject.Find("dude");
        rock = GameObject.Find("ball");


        switchToGuy();

        //gameObjects[i].SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("up"))
        {
            //Debug.Log("forward");
            transform.Translate(new Vector3(-1, 0, 0) * (speed));
        }
        else if (Input.GetKey("down"))
        {
            transform.Translate(new Vector3(1, 0, 0) * (speed));
        }

        if (Input.GetKey("left"))
        {
            this.transform.Rotate(0, -rotate_speed, 0);
        }
        else if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, rotate_speed, 0);
        }

        changeState();

    }

    void changeState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchToGuy();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){

            switchToRock();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            switchToPlane();
        }
    }

    void switchToGuy()
    {
        guy.SetActive(true);
        plane.SetActive(false);
        rock.SetActive(false);
    }

    void switchToRock()
    {
        guy.SetActive(false);
        plane.SetActive(false);
        rock.SetActive(true);
    }

    void switchToPlane()
    {
        guy.SetActive(false);
        plane.SetActive(true);
        rock.SetActive(false);
    }
}
