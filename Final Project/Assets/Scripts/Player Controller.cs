using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isOnGround = false;
    public float speed = 0.2f;
    public float jumpForce = 1;
    public float Knockback;
    private bool hitStalagmite = false;
    private Rigidbody2D playerRb;
    private Vector2 keyInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If D or A key is pressed move player in that direction
        if (Input.GetKey(KeyCode.D))
        {
            keyInput = Vector2.right;
            playerRb.AddForce(keyInput * speed, ForceMode2D.Impulse);
            Debug.Log("Worked");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            keyInput = Vector2.left;
            playerRb.AddForce(keyInput * speed, ForceMode2D.Impulse);
            Debug.Log("Worked");
        }
        //if spacebar is pressed have player jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            keyInput= Vector2.up;
            playerRb.AddForce(keyInput *jumpForce, ForceMode2D.Impulse);
            Debug.Log("jumped");
            isOnGround= false;
        }
        Vector2 hitDirection = transform.position;
        if(hitStalagmite)
        {
            playerRb.AddForce(-hitDirection * Knockback, ForceMode2D.Impulse);
            hitStalagmite = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Is On Gorund");
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stalagmite"))
        {
            hitStalagmite = true;
            Debug.Log("Touched Stalagmite");
        }
    }

}
