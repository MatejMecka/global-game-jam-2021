using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{

    private BossActionType eCurState = BossActionType.Attacking;


    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject arm;
    [SerializeField]
    private Transform gunpoint;
    private float speed = 50F;
    private float nextFire = 0.0F;
    public float fireRate = 5F;
    public int health = 100;

    public enum BossActionType
    {
            Moving,
            Attacking
    }
     

    void Start(){
    }

    void Update()
    {
        switch (eCurState)
        {
            case BossActionType.Moving:
                // HandleMovingState();
                break;
                    
           case BossActionType.Attacking:
                HandleAttackingState();
                break;
        }

    }

    private void HandleAttackingState(){
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(projectile, gunpoint.transform.position, gunpoint.transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(gunpoint.transform.up * 20, ForceMode2D.Impulse); 
        }
        arm.transform.Rotate(0,0,3);
    }

    // private void HandlePatrollingState(){
        // 
        // this.eCurState = BossActionType.Moving;
    // }

    // private void HandleMovingState(){
    //     Vector2 goalPoint = gameObject.transform.position * Random.Range(10,50) * (Random.Range(0,1) * 2 - 1);
    //     print(goalPoint);
    //     float step = speed * Time.deltaTime;
    //     gameObject.transform.position = Vector2.MoveTowards(transform.position, goalPoint,step);
    //     this.eCurState = BossActionType.Attacking;
    // }

}



