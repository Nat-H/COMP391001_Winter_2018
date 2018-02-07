using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame (not consistent) --> reads user input
	void Update () {
		
	}

    //used when performing physics calculation (will be called on the spot w/ fixed intervals, consistent)
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //returns a value between -1 and +1 whenever left, right, a, d is pushed
        float moveVertical = Input.GetAxis("Vertical"); //returns a value between -1 and +1 whenever up, down, w, s is pushed

        //Debug.Log("H = " + moveHorizontal + "V = " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); //combining two variables + stores it in movement

        Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D>(); //creates a CONNECTION to the rigidbody2D component
        rBody.velocity = movement * speed;
    }
}
