using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoWalk: MonoBehaviour
{

    public Transform[] locations;
    public float speed;
    private int current;
    public bool walkingStart = true;

    // Use this for initialization
    void Start()
    {
        transform.position = locations[0].position;
        current = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == locations[current].position && current < locations.Length - 1)
        {
            current++;
        }

        if (walkingStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, locations[current].position, speed * Time.deltaTime);
        }

    }


    private void OnCollisionStay(Collision col)
    {

    }

}
