using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    [SerializeField]
    GameObject trap;

    [SerializeField]
    GameObject fanRot;

    [SerializeField]
    private bool triggerDelayed = false;

    [SerializeField]
    private bool triggerInstant = false;

    public bool fanSoundStarted = false;

    private bool startCount = false;



    //FMOD SOUND
    GameObject laserObject;
    GameObject electricObject;

    LaserSoundScript laserSound;
    ElectricitySoundScript electricSound;

    public FMOD.Studio.EventInstance fan;

    float counter = 0;


    GameObject uc;


    private bool ePressed;

    private void Start()
    {
        //FMOD SOUND
        laserObject = GameObject.Find("LaserBarrier");
        laserSound = laserObject.GetComponent<LaserSoundScript>();
        electricObject = GameObject.FindGameObjectWithTag("CircuitTrap");
        electricSound = electricObject.GetComponent<ElectricitySoundScript>();

        uc = GameObject.Find("circuitused");

        fan = FMODUnity.RuntimeManager.CreateInstance("event:/Fan");
    }


    void Update()
    {
        if (startCount)
        {
            counter += 1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {   

            ePressed = true;
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            ePressed = false;
        }

        //FMOD SOUND
        if (Input.GetKeyDown(KeyCode.R)) {
            if (fanSoundStarted)
            {
                fan.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
        }

        if (counter >= 300)
        {
            if (fanSoundStarted)
                fan.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            fanRot.SetActive(false);
        }
        


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player"&&ePressed && this.gameObject.tag == "LaserButton") {
            trap.GetComponent<TrapScript>().activateLaserTrap();
            //Debug.Log(this.gameObject.tag);

            //FMOD SOUND
            laserSound.laser.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        if (other.gameObject.tag == "Player" && ePressed && this.gameObject.tag == "FanButton")
        {
            trap.GetComponent<TrapScript>().enabled = true;
            trap.GetComponent<BoxCollider>().enabled = true;
            //Debug.Log("FanButton");
            trap.GetComponent<TrapScript>().activateFanTrap();
            GameObject.Find("LampOn1").SetActive(false);
            GameObject.Find("LampOn2").SetActive(false);
            GameObject.Find("elec1").SetActive(false);
            GameObject.Find("elec2").SetActive(false);

            fanRot.SetActive(true);

            //FMOD SOUND
            startCount = true;
            fan.start();
            fanSoundStarted = true;
        }
        if (other.gameObject.tag == "Player" && ePressed && this.gameObject.tag == "CircuitTrap")
        {
            trap.SetActive(false);
            //uc.SetActive(true);
            EventManager.TriggerEvent("instanttrap");



            //FMOD SOUND
            electricSound.electricity.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

    }
}
