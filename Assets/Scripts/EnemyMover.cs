using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    public float moveSpeed = 3f;
    Transform firstWayPoint, secondWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        firstWayPoint = GameObject.Find("FirstWayPoint").GetComponent<Transform>();
        secondWayPoint = GameObject.Find("SecondWayPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > secondWayPoint.position.x)
        {
            movingRight = false;
        }
        if (transform.position.x < firstWayPoint.position.x)
        {
            movingRight = true;
        }

        if (movingRight == true)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    void MoveLeft()
    {
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }
}
