using UnityEngine;
using System.Collections;
//using UnityEditor;

/* Another way
		object[] objs = Resources.LoadAll("Models");
		foreach(object ob in objs){
			Object.Instantiate(ob as GameObject);
			break;
		}
*/

public class instantiate : MonoBehaviour {
	//public static Animation.AnimatorControllerParameter anim; 
	private GameObject prefabs;
	private Animator anim;
	private Avatar ava;
	private HumanDescription hum;

	// Use this for initialization
	void Start () {

		//prefabs = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/Models/mymodel.fbx", typeof(GameObject));
		prefabs = (GameObject) Resources.Load("Models/mymodels", typeof(GameObject));
        
		anim = prefabs.GetComponent<Animator> ();
		anim.runtimeAnimatorController= Resources.Load("AnimationControllers/Player", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
		//anim.avatar = (Avatar) Resources.Load("Models/AnimationControllers/Player.controller", typeof(RuntimeAnimatorController));
		//anim.runtimeAnimatorController = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/AnimationControllers/Player.controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

		// Better instantiate last or it's Animator controller wont work!
		// Probably Reason: 
		// It looks like the Animator's Controller property is private set.
		GameObject newObj = Object.Instantiate (prefabs) as GameObject;
	
		Rigidbody rigid = newObj.AddComponent<Rigidbody> ();
		rigid.isKinematic = true;
		rigid.useGravity = false;

		newObj.AddComponent<Controller> ();

		/*hum = new HumanDescription ();
		ava = AvatarBuilder.BuildHumanAvatar (newObj, hum);
		anim.avatar = ava;
		Debug.Log (ava);*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
