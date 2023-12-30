using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwoerShootBehaviour : MonoBehaviour
{
    public ProjectilesScript bullet;

    public GameObject[] shotPoint;

    private float  timeBetweenEachShot=0;

    private float desiredTime=3;

    public int towerCost;

    public int currentLevel, maxLevel;
    public int towerUpgradeCost;

    public Animator towerAnim;

    public GameObject upgradeFxPrefab;

    public TextMeshProUGUI towerUpgradeCostText;
    public float bulletSpeed;
    private void Awake()
    {
        towerAnim = GetComponent<Animator>();
        towerUpgradeCostText.text = towerUpgradeCost.ToString();
    }




    public void Shoot()
    {
        if (Time.time > timeBetweenEachShot)
        {
            // Find the nearest enemy
            GameObject nearestEnemy = FindNearestEnemy();

            if (nearestEnemy != null)
            {
                foreach (GameObject shotPoint in shotPoint)
                {
                    // Calculate direction vector towards the nearest enemy
                    Vector3 direction = nearestEnemy.transform.position - shotPoint.transform.position;
                    direction.Normalize();

                    // Instantiate the bullet at the shot point and apply force in the calculated direction
                    ProjectilesScript bulletInst = Instantiate(bullet, shotPoint.transform.position, Quaternion.identity);
                    bulletInst.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
                }
            }

            timeBetweenEachShot = Time.time + desiredTime;
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  // Adjust the tag as needed

        if (enemies.Length == 0)
        {
            return null;  // No enemies found
        }

        GameObject nearestEnemy = enemies[0];
        float nearestDistance = Vector3.Distance(transform.position, nearestEnemy.transform.position);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }



    public void UpgradeButton()
    {
        if (MainGameControlller.instance.CoinInTreasure > towerUpgradeCost && currentLevel<maxLevel)
        {
            currentLevel += 1;
            towerAnim.SetTrigger("Upgrade");
            timeBetweenEachShot -= 0.5f;
            MainGameControlller.instance.CoinInTreasure -= towerUpgradeCost;
            GameObject fxPrefab = Instantiate(upgradeFxPrefab, transform.position, Quaternion.identity);
            Destroy(fxPrefab,fxPrefab.GetComponent<ParticleSystem>().main.duration);

            //.................Play......Sound ............................


            AudioController.instance.PlayFx();


        }
    }

}// End Class....
