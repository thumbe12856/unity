using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour
{
    public bool requireKey;                     
    public AudioClip doorSwishClip;             

    AudioSource doorAudio;
    private Animator anim;                      
    private GameObject player;                  
    private GameObject door;
    private bool count;                         


    void Awake()
    {
        door = GameObject.FindGameObjectWithTag("door");
        anim = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        doorAudio = door.GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            count = true;
            anim.SetBool("open", count);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            count = false;
        anim.SetBool("open", count);
    }


    void Update()
    {
        if (anim.IsInTransition(0) && !doorAudio.isPlaying)
        {
            doorAudio.clip = doorSwishClip;
            doorAudio.Play();
        }
    }
}