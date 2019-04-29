using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed=0.5f;
    public float jumpHeight = 3f;

    private bool isMoving = false;
    private bool isJumping = false;

    [SerializeField]
    private GameObject standing;

    [SerializeField]
    private GameObject walking;

    [SerializeField]
    private GameObject dead;


    private Animator anim;

    private Rigidbody rigidBody;

    private Vector3 movement;

    

    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

        //playerSpeed /= 10;

        anim = dead.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        isMoving = false;
        float h = Input.GetAxis("Horizontal");

        

        movement = new Vector3(h, 0f, 0f);
        movement = movement.normalized;
        

        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.D)) {
            walking.GetComponent<SpriteRenderer>().flipX = true ;
            isMoving = true;
            rigidBody.MovePosition(position + movement*playerSpeed/10);
        }

        if (Input.GetKey(KeyCode.A))
        {
            walking.GetComponent<SpriteRenderer>().flipX = false;
            isMoving = true;
            rigidBody.MovePosition(position + movement * playerSpeed/10);
        }

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

    public void die() {
        isMoving = false;
        walking.SetActive(false);
        standing.SetActive(false);
        dead.SetActive(true);
        anim.SetBool("justDied", true);

        //FMOD SOUND
        FMODUnity.RuntimeManager.PlayOneShot("event:/DeathUnderling", new Vector3(0, 0, 0));
    }


}

