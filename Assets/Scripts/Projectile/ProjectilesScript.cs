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
    void Start()
    {
        //bulletBody.velocity = transform.up * bulletVelocity;
        BulletForceApply();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BulletForceApply()
    {
        bulletBody.velocity = transform.up * bulletVelocity;
        Destroy(gameObject, 4);
        //bulletBody.AddForce(new Vector2(0, bulletVelocity), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           // collision.gameObject.GetComponent<EnemyLifeBehavior>().TakeDamage(damageToEnemy);
           EnemyLifeBehavior enemyLife= collision.gameObject.GetComponent<EnemyLifeBehavior>();
            enemyLife.TakeDamage(damageToEnemy);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
