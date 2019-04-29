using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;

public class AutoWalk : MonoBehaviour
{

    

    private bool isMoving = false;
    private bool isJumping = false;

    [SerializeField]
    private GameObject standing;

    [SerializeField]
    private GameObject walking;

    private Rigidbody rigidBody;

    private Vector3 movement;



    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        isMoving = false;

        movement = new Vector3(9f, 0f, 0f);
        if (movement.magnitude >= 1f) isMoving = true;

        rigidBody.AddForce(movement);

        
        if (isJumping)
        {
            // apply extra gravity from multiplier:
            float multi = 2f;
            Vector3 extraGravityForce = (Physics.gravity * multi) - Physics.gravity;
            rigidBody.AddForce(extraGravityForce);
        }
        if (isMoving)
        {
            standing.SetActive(false);
            walking.SetActive(true);
        }
        else
        {
            standing.SetActive(true);
            walking.SetActive(false);
        }



        //anim.SetBool("isMoving", isMoving);
        //anim.SetBool("isSprinting", isSprinting);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }


}

