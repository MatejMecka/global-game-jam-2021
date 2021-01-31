using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 200;
    public int currentHealth;

    bool dead;
    bool damaged;
    float timer;	

    public float regainTime = 0.2f;
    public int healthRegenValue = 1;

    AudioSource playerAudio;
    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < startingHealth && !dead)
        {
            if(timer > regainTime)
            {
                currentHealth += healthRegenValue;
                //HealthBar.value = currentHealth;
                timer = 0;
            }

            timer += Time.deltaTime;

        }   
    }

    // Get resources
    void Awake()
    {
       // playerMovement = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();

        currentHealth = startingHealth;
        //camera = GetComponent<CameraShake>();
    }



     public void TakeDamage(int amount){

        damaged = true;
        currentHealth -= amount;

        //HealthBar.value = currentHealth;
        //camera.TriggerShake();

        if(currentHealth <= 0)
        {
            Death();
        }

    }

    void Death(){
        dead = true;
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        SceneManager.LoadScene("WrongPath", LoadSceneMode.Single);
        //playerMovement.movementDisabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            TakeDamage(20);
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject);
        }
    }
}
