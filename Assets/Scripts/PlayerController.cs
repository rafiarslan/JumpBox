using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;

    private int extraJumps;
    public int extraJumpsValue;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject gameOverText, restartButton, exitButton, pauseText, finishText, panel;

    // Use this for initialization
    void Start () {
        gameOverText.SetActive(false);
        pauseText.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        finishText.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        //Extra Jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //speed = 10;
            //jumpforce = 15;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
            SoundManagerScript.PlaySound("jump");
        }
        else if (!Input.GetKey(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            SoundManagerScript.PlaySound("jump");
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        //Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    //Flip player sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks enemy collision & restart/quit the scene
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            panel.SetActive(true);
            this.gameObject.SetActive(false);
            SoundManagerScript.PlaySound("hit");
            Time.timeScale = 0f;
        }
        if (collision.gameObject.tag.Equals("Finish"))
        {
            finishText.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            panel.SetActive(true);
            this.gameObject.SetActive(false);
            SoundManagerScript.PlaySound("finish");
            Time.timeScale = 0f;
        }

        //Extra jump and speed with wall collision
        if (collision.gameObject.tag.Equals("Walls"))
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps++;
            //speed = 12;        //Optional
            //jumpforce = 20;
        }

        //Checks platform collision on enter
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.gameObject.transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Checks platform collision on exit
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.gameObject.transform.parent = null;
        }
        if (collision.gameObject.tag.Equals("Walls"))
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps = extraJumpsValue;
        }
    }
}
