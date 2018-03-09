﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


    public float maxSpeed;
    public float jumpHeight;
    bool facingRight;
    bool grounded;
    bool crouching;

    //Declare a variable to fire
    public Transform gunTip;
    public Transform gunTipCrouching;
    public GameObject bullet;
    //public GameObject popMess;
    float fireRate = 0.5f; //fire per 0.5s
    float nextFire = 0; //fire immediately;
    //Declare Sound 
    public characterSoundManager characterSound;
    //Box collider
    BoxCollider2D boxcld;

    Rigidbody2D myBody;
    Animator myAni;
    public List<Collider2D> touchingCollider = new List<Collider2D>();


    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D> ();
        myAni = GetComponent<Animator>();
        facingRight = true;
        characterSound = GameObject.FindGameObjectWithTag("CharacterSound").GetComponent<characterSoundManager>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        myAni.SetFloat("Speed", Mathf.Abs(move));
        myAni.SetBool("Grounded", grounded);
        myAni.SetBool("Crouch", crouching);
        if (!crouching)
        {
            myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        }
        
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight) {
            flip();
        }
        if (Input.GetKey(KeyCode.W)){
            if (grounded){
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                characterSound.Playsound("jump");
            }
        }
        boxcld = GetComponent<BoxCollider2D>();
        if (Input.GetKeyDown(KeyCode.S)) {
            crouching = true;
            boxcld.size = new Vector2(5.29f, 8);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            crouching = false;
            boxcld.size = new Vector2(5.29f, 10.79f);
        }
        //Fire by mouse
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
        }
        //interact with the switch
        if (Input.GetKeyDown(KeyCode.E) && touchingCollider.Count > 0)
        {
            //touchingCollider.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
			foreach (Collider2D n in touchingCollider) {
				n.gameObject.SendMessage ("Use", SendMessageOptions.DontRequireReceiver);
			}
        }
    }

    void flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other) {
        //moving along with moving platform
        if (other.gameObject.tag == "Moving Platform")
        {
            grounded = true;
            transform.parent = other.transform;
        }
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        //stop moving with the platform when not on it
        if (other.gameObject.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        touchingCollider.Add(col);
        //popMess.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        touchingCollider.Remove(col);
        //popMess.SetActive(false);
    }


    //Fire function
    void fireBullet() {
        if(Time.time > nextFire)
        {
            characterSound.Playsound("shoot");
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                if (crouching == true)
                {
                    Instantiate(bullet, gunTipCrouching.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            }
            else if (!facingRight) {
                if (crouching == true)
                {
                    Instantiate(bullet, gunTipCrouching.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
                else
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
        }
    }
}
