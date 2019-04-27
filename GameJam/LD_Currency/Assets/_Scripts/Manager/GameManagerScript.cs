using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManagerScript : MonoBehaviour {


    private int underlingsLeft=10;


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

    }

    void SetScore() {
        underlingsLeft--;
        Debug.Log("underlingsLeft:" + underlingsLeft);
    }


    
}
