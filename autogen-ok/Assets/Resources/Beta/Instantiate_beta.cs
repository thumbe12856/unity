using UnityEngine;
using System.Collections;

public class Instantiate_beta : MonoBehaviour
{
	private Animator anim;

	void Start () {

		GameObject prefabs = (GameObject) Resources.Load("Beta/test", typeof(GameObject));

		anim = prefabs.GetComponent<Animator> ();

		anim.runtimeAnimatorController= Resources.Load("Beta/AnimationControllers/StateMachineTransitions", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
		Object.Instantiate (prefabs, new Vector3(-2,1,0),Quaternion.Euler(new Vector3(0,0,0)));

	}
	
}