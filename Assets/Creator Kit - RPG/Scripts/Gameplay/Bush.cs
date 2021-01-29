using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform target;
    public GameObject player;
    PlayerHealth playerHealth;
    public float randomNumber;
    //public Slider healthBar;
    public GameObject Ball;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     	timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) > 100 && Vector2.Distance(transform.position, target.position) < 400)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < 20)
        {
            if (timer >= betweenAttacks && health > 0)
            {

                attack();
            }
        }   
    }

    void attack(){
        if (playerHealth.currentHealth > 0)
        {
            randomNumber = Random.Range(0, 10);
            if (randomNumber % 2 == 0)
            {

            		if(playerHealth.currentHealth > 0){
	                    GameObject BallInstance = Instantiate(Ball, transform.position, transform.rotation);
	                    Rigidbody2D BallRigidbody = BallInstance.GetComponent<Rigidbody2D>();
	                    BallRigidbody.AddForce(new Vector2(-80, 0), ForceMode2D.Impulse);
	                    Destroy(BallInstance, 0.5f);
	                    playerHealth.TakeDamage(attackDamage);
	                }

                }
            timer = 0;
        }
    }






}
