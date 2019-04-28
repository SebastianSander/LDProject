using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    [SerializeField]
    GameObject trap;

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
        if (other.gameObject.tag == "Player"&&ePressed) {
            trap.active = false;
        }
    }
}
