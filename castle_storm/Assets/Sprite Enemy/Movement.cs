using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // speed platform
    public float speed;
    public Vector3 targetLocation;
    private Vector3 start;
    private Vector3 finish;

	// Use this for initialization
	void Start () {
        start = transform.position;
        finish = start + targetLocation;
	}
	
	// Update is called once per frame
	void Update () {
        MoveLeft();
	}

    void MoveLeft()
    {
        finish = new Vector3(transform.position.x - 1, 
                             transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, 
                                                 finish, 
                                                 Time.deltaTime * speed);
    }

}
