using UnityEngine;
using System.Collections;

public class LiftTrigger : MonoBehaviour
{
    public float timeToLiftStart = 2f;  
    AudioSource Audio;

    Transform parent;
    public GameObject arrow;
    private GameObject player;
    private Animator playerAnim;                  
    public bool playerInLift;
    public bool activeLift;
    private float timer;
    public bool UpAndDown;
    public bool timerToWinSwit;
    private bool arrowActive;
    public float timerToWin = 30f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Audio = GetComponent<AudioSource>();
        UpAndDown = false;

        parent = player.transform.parent;
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("UpOrDown", true);
        timerToWinSwit = false;
        activeLift = false;
        arrowActive = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            arrowActive = true;
            playerInLift = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInLift = false;
            timer = 0;
        }
    }


    void Update()
    {
        timerToWin -= Time.deltaTime;
        if (-1 <= timerToWin && timerToWin <= 0)
        {
            activeLift = true;
            timerToWinSwit = true;
        }
        
        if(arrowActive)
        {
            arrowActive = false;
            if (arrow != null)
                arrow.SetActive(false);
        }

        if (!playerInLift)
        {
            player.transform.parent = parent;
        }

        if (playerInLift || activeLift)
        {
            LiftActivation();
        }
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, nowRotationDegree + originalRotationDegree, 0), Time.deltaTime);
    }


    void LiftActivation()
    {
        timer += Time.deltaTime;
        
        if (timer >= timeToLiftStart)
        {
            if (playerInLift)
            {
                player.transform.parent = transform;
            }
            /*
            if (!Audio.isPlaying)
                // ... play the clip.
                Audio.Play();
            */
            playerAnim.SetBool("UpOrDown", UpAndDown);
            timer = 0;
            activeLift = false;
            UpAndDown = !UpAndDown;
        }
    }
}
