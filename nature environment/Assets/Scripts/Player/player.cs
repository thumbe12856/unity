﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public Camera MainCamera;
    private Animator anim;
    private Rigidbody rb;

    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;
    private bool walk;
    private Quaternion fromRotation;
    private Quaternion toRotation;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = false;
        jump = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0f);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.Play("WAIT04", -1, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift)) run = true;
        else run = false;

        if (Input.GetKey(KeyCode.Space)) jump = true;
        else jump = false;

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        if (inputH!=0 || inputV!=0) walk = true;
        else walk = false;

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("walk", walk);
        anim.SetBool("run", run);
        anim.SetBool("jump", jump);

        float moveX = inputH * 10F * Time.deltaTime * 4f;
        float moveZ = inputV * 10F * Time.deltaTime * 4f;
        
        if(run)
        {
            moveX *= 1.5f;
            moveZ *= 1.5f;
        }

        PlayerMovement(moveX, moveZ);
    }

    void PlayerMovement(float moveX, float moveZ)
    {
        //move
        Vector3 moveDirection = new Vector3(0, 0, Mathf.Abs(moveX + moveZ));

        if (moveX > 0.1)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.transform.Translate(moveDirection * Time.deltaTime);
        }
        else if (moveX < -0.1)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
            rb.transform.Translate(moveDirection * Time.deltaTime);
        }

        if (moveZ > 0.1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.transform.Translate(moveDirection * Time.deltaTime);
        }
        else if (moveZ < -0.1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.transform.Translate(moveDirection * Time.deltaTime);
        }
    }
}