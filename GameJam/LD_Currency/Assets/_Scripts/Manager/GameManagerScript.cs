using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;

public class GameManagerScript : MonoBehaviour {


    private int underlingsLeft=3;

    [SerializeField]
    ParticleSystem gas;

    [SerializeField]
    GameObject pauseMenu=null;

    [SerializeField]
    Text scoreText=null;

    [SerializeField]
    CinemachineVirtualCamera cam;
    [SerializeField]
    CinemachineVirtualCamera cam1;
    [SerializeField]
    CinemachineVirtualCamera cam2;
    

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    

    [SerializeField]
    GameObject overlord;

    GameObject laserBarrier;



    bool isPaused=false;


    private UnityAction deathListener;
    
    void Awake()
    {
        deathListener = new UnityAction(dealWithDeath);
        laserBarrier = GameObject.Find("LaserBarrier");
    }

    void OnEnable()
    {
        EventManager.StartListening("instanttrap", dealWithDeath);
        EventManager.StartListening("delaytrap", delayDeath);
        EventManager.StartListening("activatelasertrap", activateLaserTrap);
        EventManager.StartListening("activatefantrap", activateFanTrap);
    }


    void OnDisable()
    {
        EventManager.StopListening("instanttrap", dealWithDeath);
        EventManager.StopListening("delaytrap", delayDeath);
        EventManager.StopListening("activatelasertrap", activateLaserTrap);
        EventManager.StopListening("activatefantrap", activateFanTrap);
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) togglePause();
    }

    void dealWithDeath() {
        underlingsLeft--;
        scoreText.text = "Underlings left: " + underlingsLeft;
        switch (underlingsLeft)
        {
            case 2:
                cam.Priority = 1;
                player.GetComponent<PlayerMovement>().enabled = false;
                player1.GetComponent<AutoWalk>().enabled = false;
                player1.GetComponent<PlayerMovement>().enabled = true;
                break;
            case 1:
                cam1.Priority = 1;
                player1.GetComponent<PlayerMovement>().enabled = false;
                player2.GetComponent<AutoWalk>().enabled = false;
                player2.GetComponent<PlayerMovement>().enabled = true;
                break;
            case 0:
                player2.GetComponent<PlayerMovement>().enabled = false;
                Debug.Log("noone Left");
                
                break;
            
        }
        
    }

    void delayDeath() {
        Debug.Log("test");
    }
    
    void activateLaserTrap()
    {
        // anim.Bool.Laseractivated = false;
        laserBarrier.SetActive(false);
    }

    void activateFanTrap()
    {
        Debug.Log("Fan activated");
        gas.GetComponent<ParticleMovement>().gasButton = true;
    }

void togglePause() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    
}
