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
    public float thrust = 10f;
    public float jumpthrust = 10f;
    string state = "guy";
    bool isGrounded = false;
    GameObject the_other_object;
    Vector3 lastpos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        plane = GameObject.Find("plane");
        guy = GameObject.Find("dude");
        rock = GameObject.Find("ball");
        the_other_object = GameObject.Find("ground");


        switchToGuy();

        //gameObjects[i].SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case "guy":
                moveFrontBack();
                moveLeftRight();
                break;
            case "plane":
                glide();
                moveLeftRight();
                break;
        }
        

       

        changeState();
        checkGround();

    }

    void checkGround()
    {
        Vector3 currentpos = this.transform.position;
        int y1 = (int)(currentpos.y * 1000f);
        int y2 = (int)(lastpos.y * 1000f);

        if (y1 == y2)
        {
            isGrounded = true;
        }
        else isGrounded = false;

        lastpos = currentpos;
    }

    void glide()
    {

        if (!isGrounded)
        {
            transform.Translate(new Vector3(-1, 0, 0) * (speed));

        }
        
    }

    



    void moveFrontBack()
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
    }

    void moveLeftRight()
    {
        if (Input.GetKey("left"))
        {
            this.transform.Rotate(0, -rotate_speed, 0);
        }
        else if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, rotate_speed, 0);
        }
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

        rb.mass = 10f;
        state = "guy";
    }

    void switchToRock()
    {
        guy.SetActive(false);
        plane.SetActive(false);
        rock.SetActive(true);

        rb.mass = 10f;
        rb.AddForce(new Vector3(0,-1,0) * thrust);
        state = "rock";
    }

    void switchToPlane()
    {
        guy.SetActive(false);
        plane.SetActive(true);
        rock.SetActive(false);

        rb.mass = 0.1f;
        rb.AddForce(transform.up * jumpthrust);
        state = "plane";
    }
}
