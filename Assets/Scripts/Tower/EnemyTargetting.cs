using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetting : MonoBehaviour
{
    //public List<GameObject> numberOfEnemies;
    public GameObject[] numberOfEnemies;
    public Transform nearestEnemy=null;
    public TwoerShootBehaviour TSBehaviurRef;

    public bool enemyFound=false;
    public ProjectilesScript bulletScriptRef;
    public bool shootOrNot=false;
    void Start()
    {
        
    }

    void Update()
    // Update is called once per frame
    {
        FindEnemyNearest();

        if (enemyFound)
        {
            if (shootOrNot)
            {
                targetedDirToEnemy();

                TSBehaviurRef.Shoot();
            }
           
        }
       

    }

    void targetedDirToEnemy()
    {
        Vector3 dire = nearestEnemy.transform.position - transform.localPosition;
      //  Debug.Log("dire==" + dire);
        float angle = Mathf.Atan2(dire.y , dire.x) * Mathf.Rad2Deg;
       // Debug.Log(angle);
         transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        
        //Debug.Log("transform.rotation ==" + transform.rotation);
    }
    public void FindEnemyNearest()
    {
        float nearestEnemyDistance = 1000f;

        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy") ;
    
        foreach (GameObject enemies in numberOfEnemies)
        {
            float distance = Vector2.Distance(transform.localPosition , enemies.transform.position);
            if (distance<nearestEnemyDistance)
            {
                nearestEnemyDistance = distance;
                nearestEnemy = enemies.transform;
                
            }
        }

        enemyFound = true;
    }

  

   
}
