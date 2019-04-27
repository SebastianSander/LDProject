using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController1 : MonoBehaviour {


    private UnityAction deathListener;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            //Debug.Log("Event Trigger");

            
            EventManager.TriggerEvent("trap");

            
        }
    }

    



}
