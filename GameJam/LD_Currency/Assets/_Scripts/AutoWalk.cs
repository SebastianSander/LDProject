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

    //FMOD SOUND
    private FMOD.Studio.EventInstance walkingCaptain;



    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

        movement = new Vector3(1f, 0f, 0f);

        //FMOD SOUND does nothing
        walkingCaptain = FMODUnity.RuntimeManager.CreateInstance("event:/WalkingOverlord");
        //walkingCaptain.start();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {


        Vector3 position = transform.position;
        if (up) transform.position = position+new Vector3(0.5f,1.0f,0);

        rigidBody.MovePosition(position + movement * playerSpeed / 10);

        //SOUND FMOD


        

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
            //Vector3 position = transform.position;
            //if (up) transform.position = position + new Vector3(0.6f, 0.2f, 0);
        }
    }




}
