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
    private void Awake()
    {
        towerAnim = GetComponent<Animator>();
        towerUpgradeCostText.text = towerUpgradeCost.ToString();
    }
  

    // Update is called once per frame
    void Update()
    {

        

    }

    public void Shoot()
    {
        if (Time.time > timeBetweenEachShot)
        {

            foreach (GameObject shotpoints in shotPoint)
            {
                Debug.Log("calling time");
                ProjectilesScript bulletInst = Instantiate(bullet, transform.localPosition, shotpoints.transform.localRotation);
               // bulletInst.GetComponent<Rigidbody2D>().AddForce(shotpoints.transform.rotation, ForceMode2D.Impulse);
            }

           
            timeBetweenEachShot = Time.time + desiredTime;

        }


    }// End Shoot..............




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
