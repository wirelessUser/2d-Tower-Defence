using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerCreation : MonoBehaviour
{
    public List<GameObject> placedTowerList = new List<GameObject>();
    public List<Collider2D> PlacedTowerColldier = new List<Collider2D>();

    public TowerButtonScript towerButtonref;

    public SpriteRenderer towerCreationSprite;

   
    



    private void Awake()
    {
        towerCreationSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Vector3 thisPos = this.transform.position;
        thisPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        thisPos.z = 0;
        this.transform.position = thisPos;
        DetectInput();
    }


    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
       {
            Vector3 mousepose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitray = Physics2D.Raycast(mousepose, Vector2.zero);
        if (hitray.collider != null)
        {
                PlaceTowerOnlyAtDesiredPos(hitray);
            }

            
            //CreateTower();
    }
    }

  
    public void SetButtonRef(TowerButtonScript towerButton)
    {
        towerButtonref = towerButton;
        if (MainGameControlller.instance.CoinInTreasure > towerButtonref.towerCost)
        {
            
            MosueDownObjectAtTipAdd();
        }


    }
    //private void SetTowerPosWithMouse(GameObject towerInst)
    //{
    //    Vector3 mousepose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    towerInst.transform.position = new Vector2(mousepose.x, mousepose.y);
    //}

    void PlaceTowerOnlyAtDesiredPos(RaycastHit2D hitray)
    {
        Debug.Log("Name Hitray" + hitray.collider.gameObject);

        if (hitray.collider.tag== "BuildArea" && MainGameControlller.instance.CoinInTreasure >towerButtonref.towerCost)
        {
            hitray.collider.tag = "OccupiedPlace";


            //  Craete tower At only collider location choosen By us.........


            GameObject towerInst = Instantiate(towerButtonref.towerObejct);
            Vector3 temp = towerInst.transform.position;
            // temp = hitray.collider.transform.position;
            //  temp = hitray.transform.position; it's a same thigs as above
            int towerCost = towerInst.GetComponent<TwoerShootBehaviour>().towerCost;
            temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 0;
            towerInst.transform.position= temp;
            MosueUpObjectAtTipRemove();
            DeductCoinAfterTowerPlaced(towerButtonref);
            AddTowerObjectAndColliderToTheList(towerInst, hitray.collider);
        }
       
    }



    public void DeductCoinAfterTowerPlaced(TowerButtonScript towerCost)
    {
        MainGameControlller.instance.CoinInTreasure -= towerCost.towerCost;
    }

    public void AddCoin(int coinAdd)
    {
        MainGameControlller.instance.CoinInTreasure += coinAdd;
    }
    void AddTowerObjectAndColliderToTheList(GameObject towerCreated,Collider2D colliderHitRay)
    {
        placedTowerList.Add(towerCreated);
        PlacedTowerColldier.Add(colliderHitRay);
    }

    public void MosueDownObjectAtTipAdd()
    {
        towerCreationSprite.sprite = towerButtonref.draggedSprite;
        towerCreationSprite.enabled = true;
    }
    public void MosueUpObjectAtTipRemove()
    {
       
        towerCreationSprite.sprite = towerButtonref.draggedSprite;
        towerCreationSprite.enabled = false;
    }
}
