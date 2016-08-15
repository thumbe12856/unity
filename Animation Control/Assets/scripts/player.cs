using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public Camera MainCamera;
    public Animator anim;
    public Rigidbody rb;

    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;
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

        if (Input.GetMouseButtonDown(0))
        {
            int n = Random.Range(0, 2);
            if(n==0) anim.Play("DAMAGED00", -1, 0f);
            else anim.Play("DAMAGED01", -1, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift)) run = true;
        else run = false;

        if (Input.GetKey(KeyCode.Space)) jump = true;
        else jump = false;

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);
        anim.SetBool("jump", jump);

        float moveX = inputH * 20F * Time.deltaTime;
        float moveZ = inputV * 50F * Time.deltaTime;

        if(moveZ <= 0F)
        {
            moveX = 0F;
        }
        else if(run)
        {
            moveX *= 3F;
            moveZ *= 3F;
        }

        //rb.velocity = new Vector3(moveX, 0f, moveZ);
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        rb.transform.Translate(moveDirection * Time.deltaTime);
    }
}
