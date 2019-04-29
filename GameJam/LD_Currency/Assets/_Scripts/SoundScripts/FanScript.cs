using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour {

    //FMOD SOUND
    GameObject button;


    ButtonScript buttonScript;


    // Use this for initialization
    void Start () {
        button = GameObject.FindGameObjectWithTag("FanButton");
        buttonScript = button.GetComponent<ButtonScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if(buttonScript.fanSoundStarted) buttonScript.fan.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
