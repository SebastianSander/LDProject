using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDownScript : MonoBehaviour {

    Collider f_Collider;

    bool sPressed = false;
    private float disableTime = 1f;

	void Start () {
        f_Collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            sPressed = true;  
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            sPressed = false ;
        }

        if (!f_Collider.enabled) disableTime -= Time.deltaTime;
        if (disableTime <= 0) {
            disableTime = 1f;
            f_Collider.enabled = true;
        }

    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player"&&sPressed)
        {

            f_Collider.enabled = !f_Collider.enabled;
            Debug.Log("Collider.enabled = " + f_Collider.enabled);
             
        }
    }
}
