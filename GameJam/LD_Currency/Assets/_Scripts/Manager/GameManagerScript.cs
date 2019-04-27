using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {


    private int underlingsLeft=10;


    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    Text scoreText;

    


    //[SerializeField]
    //GameObject player1;
    //[SerializeField]
    //GameObject player2;

    bool isPaused=false;


    private UnityAction deathListener;
    private UnityAction changeChar;


    void Awake()
    {
        deathListener = new UnityAction(dealWithDeath);
    }

    void OnEnable()
    {
        EventManager.StartListening("trap", dealWithDeath);
    }

    void OnDisable()
    {
        EventManager.StopListening("trap", dealWithDeath);
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

        //player1.GetComponent<PlayerController>().enabled = false;
        //player2.GetComponent<PlayerController>().enabled = true;



        EventManager.TriggerEvent("changeChar");
    }

    void togglePause() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    
}
