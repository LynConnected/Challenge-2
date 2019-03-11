﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        SetCountText();
        SetLivesText();
        winText.text = "";

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {

            if(Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);

            }

        }
        if (collision.collider.tag == "Platform")
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);

            }

        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        if (lives == 0) //this number should be equal to original value lives - lives
        {
            Destroy(this.gameObject);
        }
        if (count == 4) //this number should be equal to the number of yellow pickups on the first playfield
        {
            transform.position = new Vector2(0, 14);
            lives = 3;
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You win!";
        }
    }
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You lose!";
        }
    }
   
}
