using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleMovement : MonoBehaviour
{

    public Transform[] locations;
    public float speed;
    private int current;
    public bool gasButton;
    [SerializeField]
    public ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        transform.position = locations[0].position;
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == locations[current].position && current < locations.Length - 1)
        {
            current++;
        }

        if (gasButton)
        {
            transform.position = Vector3.MoveTowards(transform.position, locations[current].position, speed * Time.deltaTime);
        }

        if (current == locations.Length-1) {
           ps.Stop();
           

        } 

        /*for (int i = 0; i < locations.Length - 1; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, locations[i].position, speed * Time.deltaTime);
        }*/

    }

    public void setActiveBool(bool gasButton) {
        this.gasButton = gasButton;
    }


    


}
