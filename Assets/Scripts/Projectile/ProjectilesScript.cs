using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesScript : MonoBehaviour
{
    public int damageToEnemy=20;
    public Rigidbody2D bulletBody;
    public float bulletVelocity = 5;

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody2D>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
           EnemyLifeBehavior enemyLife= collision.gameObject.GetComponent<EnemyLifeBehavior>();
            enemyLife.TakeDamage(damageToEnemy);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "offScreen")
        {
            //Debug.Log("Collided OffScreen");
            Destroy(gameObject);
        }

    }

   
}
