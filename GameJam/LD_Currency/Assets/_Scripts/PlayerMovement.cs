using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed=1f;
    public float jumpHeight = 3f;

    private bool isMoving = false;
    private bool isJumping = false;
    

    private Animator anim;
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {

       
        //anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            isMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&!isJumping)
        {
            //transform.Translate(Vector3.up * jumpHeight);
            Vector3 newForce = new Vector3(0f, 1f, 0f);
            rigidBody.AddForce(newForce*jumpHeight, ForceMode.Impulse);
            isJumping = true;
            
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

