using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {
    private GameObject player;
    private Animator anim;
    PlayerHealth playerMovement;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerHealth>();
    }

	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetTrigger("win");
            playerMovement.isWin = true;
        }
    }

}
