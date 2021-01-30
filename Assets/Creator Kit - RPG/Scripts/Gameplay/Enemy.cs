using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;
    private Transform target;
    public GameObject player;
    public float randomNumber;

    PlayerHealth playerHealth;

    // Sound
	AudioSource enemyAudioSource;
    public AudioClip attackClip;


    public float health = 100;
    public float timer;

    // Attack stuff

    public int attackDamage = 20;
    public float betweenAttacks = 3f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyAudioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 0 && Vector2.Distance(transform.position, target.position) < 20){
        	Debug.Log("exec")
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }	

        if (Vector2.Distance(transform.position, target.position) < 5){
            if (timer >= betweenAttacks && health > 0){
                attack();
            }
        }


    }

    void attack(){

        if(playerHealth.currentHealth > 0){
            randomNumber = Random.Range(0, 25);
            enemyAudioSource.clip = attackClip;
            enemyAudioSource.Play();
            if (randomNumber % 2 == 0){
                playerHealth.TakeDamage(attackDamage);      
            }
            timer = 0;
        }

    }


}
