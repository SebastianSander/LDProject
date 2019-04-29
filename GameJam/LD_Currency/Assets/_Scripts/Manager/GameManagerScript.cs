using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

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

    private int ULcount=2;

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
        EventManager.StartListening("endgameneg", endGameNeg);
    }


    void OnDisable()
    {
        EventManager.StopListening("instanttrap", dealWithDeath);
        EventManager.StopListening("delaytrap", delayDeath);
        EventManager.StopListening("activatelasertrap", activateLaserTrap);
        EventManager.StopListening("activatefantrap", activateFanTrap);
        EventManager.StopListening("endgameneg", endGameNeg);
    }

    void Start() {
        togglePause();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) togglePause();
        if (Input.GetKeyDown(KeyCode.R))SceneManager.LoadScene(1);
    }

    void dealWithDeath() {
        underlingsLeft--;
        scoreText.text = "Underlings left: " + underlingsLeft;
        Debug.Log("before switch"+ULcount);
        switch (ULcount)
        {
            case 2:
                cam.Priority = 1;
                player.GetComponent<PlayerMovement>().die();
                player.GetComponent<PlayerMovement>().enabled = false;
                player1.GetComponent<AutoWalk>().enabled = false;
                player1.GetComponent<PlayerMovement>().enabled = true;
                ULcount--;
                break;
            case 1:
                cam1.Priority = 1;
                player1.GetComponent<PlayerMovement>().die();
                player1.GetComponent<PlayerMovement>().enabled = false;
                player2.GetComponent<AutoWalk>().enabled = false;
                player2.GetComponent<PlayerMovement>().enabled = true;
                ULcount--;
                break;
            case 0:
                player2.GetComponent<PlayerMovement>().die();
                player2.GetComponent<PlayerMovement>().enabled = false;
                cam2.Priority = 1;
                Debug.Log("noone Left");
                ULcount--;
                break;
            case -1:
                
                Debug.Log("camset");
                break;
        }
        Debug.Log(ULcount);
        
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

    void endGameNeg() {
        Debug.Log("Overlord died");
        FMODUnity.RuntimeManager.PlayOneShot("event:/DeathOverlord", new Vector3(0, 0, 0));
        SceneManager.LoadScene(2);
    }

    
}
