using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

    public float moveSpeed = 3f;
    public bool moveRight = true;
    public float platformPositionOne;
    public float platformPositioTwo;

    // Update is called once per frame
    void Update () {
        if (transform.position.x >= platformPositionOne)
        {
            moveRight = false;
        }
        if (transform.position.x < platformPositioTwo)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
	}
}
