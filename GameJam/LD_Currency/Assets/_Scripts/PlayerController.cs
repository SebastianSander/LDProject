using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float jumpForce=1;
    private bool isJumping = false;

    

    Rigidbody player = null;

    




    void Start()
    {
        player = GetComponent<Rigidbody>();

    }
	
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0f);

        player.AddForce(movement * speed);
        

        if (Input.GetKeyDown(KeyCode.Space)&&!isJumping) {

            Vector3 jump = new Vector3(0f, 30f, 0f);
            player.AddForce(jump * jumpForce);
            isJumping = true;
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor"&&isJumping)
        {
            isJumping = false;
            Debug.Log("test");
        }
    }


}
