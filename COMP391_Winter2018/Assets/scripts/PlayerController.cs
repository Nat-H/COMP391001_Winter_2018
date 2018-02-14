using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Boundary Class
[System.Serializable]   // to allow own code to be seen by Unity
public class Boundary
{
    public float xMin, xMax, yMin, yMax; // create own class for the axes

}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary; // creates an instance of the class
    public GameObject laser;
    public Transform laserSpawn;

    // private variables
    private Rigidbody2D rBody;
    private float nextFire = 0.25f;
    private float timeCounter = 0.0f;

	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();   // creates a CONNECTION to the rigidbody2D component
    }
	
	// Update is called once per frame (not consistent) --> reads user input
	void Update () {
        timeCounter += Time.deltaTime;

        if (Input.GetButton("Fire1") && timeCounter > nextFire)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);

            timeCounter = 0.0f;
        }
	}

    // used when performing physics calculation (will be called on the spot w/ fixed intervals, consistent)
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // returns a value between -1 and +1 whenever left, right, a, d is pushed
        float moveVertical = Input.GetAxis("Vertical"); // returns a value between -1 and +1 whenever up, down, w, s is pushed

        //Debug.Log("H = " + moveHorizontal + "V = " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // combining two variables + stores it in movement

        //Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D>(); //
        rBody.velocity = movement * speed;
        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, -8.5f, 3.0f), Mathf.Clamp(rBody.position.y, -4.0f, 4.0f));
        //rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, xMin, xMax), Mathf.Clamp(rBody.position.y, yMin, yMax));
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));


    }
}
