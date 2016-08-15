using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public Animator anime;
	public Rigidbody rb;
	public float WalkScale = 5, RunScale = 5,SlideScale = 5;
	private bool run;
	private bool jump;
	private bool slide;
	private float inputH;
	private float inputV;
	private float motionScale;
	private bool JumpTempFlag = true;
	private Vector3 eulerAngleVelocity;
	
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		slide = run = jump = false;
		motionScale = WalkScale;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("escape"))
			Application.Quit();
		
		inputV = Input.GetAxis ("Vertical");
		inputH = Input.GetAxis ("Horizontal");
		
		if (Input.GetKeyDown ("1")) {
			anime.Play ("WAIT01", -1, 0f);
		}
		else if (Input.GetKeyDown ("2")) {
			anime.Play ("WAIT02", -1, 0.5f);
		} else if (Input.GetKeyDown ("3")) {
			anime.Play ("WAIT03", -1, 0f);
		}
		else if (Input.GetKeyDown ("4")) {
			anime.Play ("WAIT04", -1, 0f);
		}
		
		if (Input.GetMouseButtonDown (0)) { // left key of mouse
			anime.Play ("DAMAGED00", -1, 0f);
		}
		else if (Input.GetMouseButtonDown (1)) { // right key of mouse
			anime.Play ("DAMAGED01", -1, 0f);
		}
		if (Input.GetKey (KeyCode.LeftShift) && inputV > 0)
			run = true;
		else
			run = false;
		
		if (Input.GetKey (KeyCode.Space))
			jump = true;
		else
			jump = false;
		
		if (anime.GetCurrentAnimatorStateInfo (0).IsName ("SLIDE00")) {
			jump = false;
			slide = true;
		}
		else
			slide = false;

		anime.SetFloat ("input_h", inputH);
		anime.SetFloat ("input_v", inputV);
		anime.SetBool ("run", run);
		anime.SetBool ("jump", jump);
		anime.SetBool ("slide", slide);
		
		if (run) {
			motionScale = RunScale;
		} else {
			motionScale = WalkScale;
		}
		
		if (slide)
			motionScale = SlideScale;
		
		
		if (anime.GetCurrentAnimatorStateInfo (0).IsName ("Walk") || anime.GetCurrentAnimatorStateInfo (0).IsName ("Run") || anime.GetCurrentAnimatorStateInfo (0).IsName ("SLIDE00") || anime.GetCurrentAnimatorStateInfo (0).IsName ("JUMP00")) {
			rb.velocity = transform.forward * motionScale * Time.deltaTime; //new Vector3 (moveX, moveY, moveZ);
			if(inputV < 0) rb.velocity *= -1;
		}
		else
			rb.velocity = new Vector3(0f,0f,0f);
		
		// dealing rotation
		if (Input.GetKey (KeyCode.D) || Input.GetAxis("Mouse X") > 0) {
			eulerAngleVelocity = new Vector3 (0f, 80f, 0f);
		} 
		else if (Input.GetKey (KeyCode.A) || Input.GetAxis("Mouse X") < 0) {
			eulerAngleVelocity = new Vector3 (0f, -80f, 0f);
		} 
		else {
			eulerAngleVelocity = new Vector3 (0f, 0f, 0f);
		}
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rb.MoveRotation(rb.rotation* deltaRotation);
		
		if (Input.GetKeyDown (KeyCode.Space) && 
		    !(anime.GetCurrentAnimatorStateInfo(0).IsName("WAIT01") || 
		  anime.GetCurrentAnimatorStateInfo(0).IsName("WAIT02") || 
		  anime.GetCurrentAnimatorStateInfo(0).IsName("WAIT03") || 
		  anime.GetCurrentAnimatorStateInfo(0).IsName("WAIT04")
		  )
		    ) {

			JumpTempFlag = !JumpTempFlag;
		}
	}
}