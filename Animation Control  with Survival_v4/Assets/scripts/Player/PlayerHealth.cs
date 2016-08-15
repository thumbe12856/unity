using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 300;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public AudioClip winClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public GameObject MainCamera;
    camera Camera;
    Animator anim;
    AudioSource playerAudio;
    player playerMovement;
    PlayerShooting playerShooting;
    public bool isWin;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        Camera = MainCamera.GetComponent<camera>();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <player> (); 
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            anim.Play("DAMAGED00", -1, 0f);
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (currentHealth > 0 && isWin)
        {
            Win();
            isWin = false;
        }
    }


    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (!playerAudio.isPlaying)
            playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    void Win()
    {
        playerShooting.DisableEffects();

        if (!playerAudio.isPlaying)
            playerAudio.clip = winClip;
        playerAudio.loop = true;
        playerAudio.Play();

        Camera.fighting = false;
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");
        anim.Play("LOSE00", -1, 0f);

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        Application.LoadLevel (Application.loadedLevel);
    }
}
