using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour {

    //SOUND FMOD
    private FMOD.Studio.EventInstance backgroundMusic;
    bool musicStarted = false;

    // Use this for initialization
    void Start () {
        //SOUND FMOD
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/BackgroundMusic");

        if (!musicStarted)
        {
            backgroundMusic.start();
            musicStarted = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
