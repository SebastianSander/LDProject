using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapScript : MonoBehaviour {

    private UnityAction deathListener;

    [SerializeField]
    private bool delay;

    [SerializeField]
    private float delayTime = 3;

    [SerializeField]
    private GameObject actionObject;



    private bool trigger = false;

    private void FixedUpdate()
    {
        if (delay)
        {
            if (trigger) delayTime -= Time.deltaTime;

            if (delayTime <= 0f)
            {
                //Debug.Log("test");
                triggerDelayedTrap();
            }
        }
        if(this.gameObject.name=="LaserBall2")if (gameObject.transform.position.x <= actionObject.transform.position.x && actionObject.activeInHierarchy) this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == "Player" && delay)
        {
            Debug.Log("Event Trigger");

            trigger = true;

        }      
        else if ((other.gameObject.tag == "Player" || other.gameObject.tag=="Overlord") && gameObject.tag == "Pressure1")
        {
            //triggerInstantTrap();

            actionObject.GetComponent<ParticleMovement>().setActiveBool(true);
            gameObject.SetActive(false);
            
        }
        else if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Overlord") && gameObject.tag == "Pressure2")
        {
            //triggerInstantTrap();

            actionObject.GetComponent<ParticleMovement>().setActiveBool(true);
            gameObject.SetActive(false);


        }
        else if (other.gameObject.tag == "Player"&&gameObject.tag!= "Pressure1"&& gameObject.tag != "Pressure2")
        {
            triggerInstantTrap();

            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Overlord" && gameObject.tag != "Pressure1" && gameObject.tag != "Pressure2")
        {

            
            //triggerInstantTrap();
            EventManager.TriggerEvent("endgameneg");
            
            gameObject.SetActive(false);
        }

        
    }

        public void activateLaserTrap()
        {
            EventManager.TriggerEvent("activatelasertrap");
            this.enabled = false;
        }

        public void activateFanTrap()
        {
            EventManager.TriggerEvent("activatefantrap");
            this.enabled = false;
        }

        public void triggerDelayedTrap() {
            EventManager.TriggerEvent("delaytrap");
            this.enabled = false;
        }

        public void triggerInstantTrap()
        {
            EventManager.TriggerEvent("instanttrap");
            this.enabled = false;
        }
    
    

}
