using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{

    public Transform[] locations;
    public float speed;
    private int current;

    // Use this for initialization
    void Start()
    {
        transform.position = locations[0].position;
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (transform.position == locations[current].position)
        {
            current++;
        }
        transform.position = Vector3.MoveTowards(transform.position, locations[current].position, speed * Time.deltaTime);

        //wiederholung
        /*if (current >= locations.Length)
        {
            current = 0;
        }*/


        //transform.position = Vector3.MoveTowards(transform.position, locations[current].position, speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision col)
    {
        
    }
}





/*public class ParticleScript : MonoBehaviour {

    public GameObject gas;
    [SerializeField]
    bool fanButtonPressed = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fanButtonPressed) {
            gas.transform. += 1;
        }
	}


}
*/
