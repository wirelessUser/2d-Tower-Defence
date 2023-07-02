using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeBehavior : MonoBehaviour
{
   public int maxHealth,currentHealth;

    public int damageAmount;

    public bool isDead = false;
    public Animator enemyAnim;
    public int AddcointAfterDie;
    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("currentHealth ==" + currentHealth);
        enemyAnim.SetTrigger("Damage");
        if (currentHealth<=0)
        {
            TowerCreation toweCreatRef = GameObject.Find("TowerCreator").GetComponent<TowerCreation>();
            toweCreatRef.AddCoin(AddcointAfterDie);
            enemyAnim.SetTrigger("Dead");
            isDead = true;
            Destroy(gameObject);
           
        }
    }















}
