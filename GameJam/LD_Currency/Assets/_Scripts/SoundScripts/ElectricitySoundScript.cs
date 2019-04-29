using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricitySoundScript : MonoBehaviour {

    private FMOD.Studio.ParameterInstance entfernung;
    public FMOD.Studio.EventInstance electricity;

    private float dist = 1;

    private GameObject camera;

    private bool trig = false;



    // Use this for initialization
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

        electricity = FMODUnity.RuntimeManager.CreateInstance("event:/Electricity");

        if (electricity.getParameter("Entfernung", out entfernung) != FMOD.RESULT.OK)
        {
            Debug.LogError("Entfernung parameter not found on laser event");
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 distance = camera.transform.position - this.transform.position;
        dist = Mathf.Clamp(Mathf.Abs(distance.x), 0, 1);


        entfernung.setValue(dist);

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (trig) electricity.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            dist = 1;
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("LoseEnd"))
            || SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("WinEnd")))
        {
            if (trig) electricity.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

    }

    private void OnTriggerEnter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            electricity.start();
            FMODUnity.RuntimeManager.PlayOneShot("event:/DoorOpen", new Vector3(0, 0, 0));
            trig = true;
        }
        
    }
}
