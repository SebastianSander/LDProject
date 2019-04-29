using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoWalk : MonoBehaviour
{
    private float playerSpeed = 0.2f;
    private float jumpHeight = 3f;

    private bool isMoving = false;
    private bool isJumping = false;

    [SerializeField]
    private GameObject standing;

    [SerializeField]
    private GameObject walking;

    private Rigidbody rigidBody;

    private Vector3 movement;

    bool up = false;



    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

        movement = new Vector3(1f, 0f, 0f);
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {


        Vector3 position = transform.position;
        if (up) transform.position = position+new Vector3(0f,1.1f,0);

        rigidBody.MovePosition(position + movement * playerSpeed / 10);

        

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "JumpTrigger") {

            up = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "JumpTrigger")
        {

            up = false;
        }
    }




}
