using UnityEngine;
using System.Collections;

public class PlayerIsDown : MonoBehaviour {
    private GameObject player;
    private GameObject lift;
    LiftTrigger liftTri;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (liftTri.timerToWinSwit && !liftTri.playerInLift && !liftTri.UpAndDown)
            {
                liftTri.activeLift = true;
            }
        }
    }
    
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lift = GameObject.FindGameObjectWithTag("lift");
        liftTri = lift.GetComponent<LiftTrigger>();
    }
}
