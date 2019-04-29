using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed=1f;
    public float jumpHeight = 3f;

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
        float h = Input.GetAxis("Horizontal");
        movement =  h * Vector3.right * playerSpeed * 5;

        if (movement.magnitude >= 1f) isMoving = true;

        rigidBody.AddForce(movement);

        if (Input.GetKeyDown(KeyCode.Space)&&!isJumping)
        {
            Vector3 newForce = new Vector3(0f, 1f, 0f);
            rigidBody.AddForce(newForce*jumpHeight, ForceMode.Impulse);
            isJumping = true;
            
        }
        if (isJumping) {
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
        else {
            standing.SetActive(true);
            walking.SetActive(false);
        }
        
        

        //anim.SetBool("isMoving", isMoving);
        //anim.SetBool("isSprinting", isSprinting);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") {
            isJumping = false;
        }
    }

    
}

