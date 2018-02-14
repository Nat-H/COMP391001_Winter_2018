using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserMove : MonoBehaviour {

    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = this.transform.right;  // set velocity = (1, 0);



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
