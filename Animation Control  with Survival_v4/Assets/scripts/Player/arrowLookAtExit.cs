using UnityEngine;
using System.Collections;

public class arrowLookAtExit : MonoBehaviour {

    public GameObject Exit;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "prop_lift_collider")
        {
            Destroy(gameObject, 2f);
        }
    }
    
    void Update ()
    {
        transform.LookAt(Exit.transform);
	}
}
