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

    bool isPaused=false;


    private UnityAction scoreListener;

    void Awake()
    {
        scoreListener = new UnityAction(SetScore);
    }

    void OnEnable()
    {
        EventManager.StartListening("trap", SetScore);
    }

    void OnDisable()
    {
        EventManager.StopListening("trap", SetScore);
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) togglePause();
    }

    void SetScore() {
        underlingsLeft--;
        scoreText.text = "Underlings left: " + underlingsLeft;
    }

    void togglePause() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    
}
