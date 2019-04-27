using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDownScript : MonoBehaviour {

    Collider f_Collider;

    bool sPressed = false;

	void Start () {
        f_Collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sPressed = true;  
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player"&&sPressed)
        {

            f_Collider.enabled = !f_Collider.enabled;
            Debug.Log("Collider.enabled = " + f_Collider.enabled);
            
        
        }
    }
}
