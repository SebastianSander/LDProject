using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapScript : MonoBehaviour {

    private UnityAction deathListener;

    [SerializeField]
    private bool delay;

    [SerializeField]
    private float delayTime = 3;

    

    private bool trigger = false;

    private void FixedUpdate()
    {
        if (delay)
        {
            if (trigger) delayTime -= Time.deltaTime;

            if (delayTime <= 0f)
            {
                //Debug.Log("test");
                EventManager.TriggerEvent("delaytrap");
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && delay)
        {
            Debug.Log("Event Trigger");

            trigger = true;

        }
        else if (other.gameObject.tag == "Player") {
            EventManager.TriggerEvent("instanttrap");
            this.enabled = false;
        }


    }

}
