using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    [SerializeField]
    GameObject trap;

    [SerializeField]
    private bool triggerDelayed = false;

    [SerializeField]
    private bool triggerInstant = false;

    private bool ePressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   

            ePressed = true;
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            ePressed = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player"&&ePressed && this.gameObject.tag == "LaserButton") {
            trap.GetComponent<TrapScript>().activateLaserTrap();
            //Debug.Log(this.gameObject.tag);
        }
        if (other.gameObject.tag == "Player" && ePressed && this.gameObject.tag == "FanButton")
        {
            //Debug.Log("FanButton");
            trap.GetComponent<TrapScript>().activateFanTrap();
        }

    }
}
