using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController1 : MonoBehaviour {



    [SerializeField]
    private float jumpForce=1;
    private bool isJumping = false;

   


    private UnityAction deathListener;

    private UnityAction changeChar;





    void Start()
    {
    }
	
	
	void FixedUpdate () {
        

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            //Debug.Log("Event Trigger");
            EventManager.TriggerEvent("trap");
            
        }
    }

    



}
