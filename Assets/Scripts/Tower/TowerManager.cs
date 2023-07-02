//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class TowerManager : MonoBehaviour
//{
//    public TowerButtonScript towerButtonRef;

//    public SpriteRenderer towerSprite;

//    public Collider2D buildTileCollider;

//    public List<Collider2D> buildLits = new List<Collider2D>();
//    public List<GameObject> towerList = new List<GameObject>();

//    void Start()
//    {
//        towerSprite = GetComponent<SpriteRenderer>();
//        buildTileCollider = GetComponent<Collider2D>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        GettingMouseInput();

//        if (towerSprite.enabled)
//        {
//            FollowMouse();
//        }
//    }

//    private void FollowMouse()
//    {
//       Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        this.transform.position = new Vector2(mousePos.x, mousePos.y);

//    }

//    public void GettingMouseInput()
//    {
        
//        if (Input.GetMouseButtonDown(0))
//        {
//            Vector3 cameraPosGameWrold = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//            RaycastHit2D hit = Physics2D.Raycast(cameraPosGameWrold, Vector2.zero);


//            if (hit.collider.tag=="BuildArea")
//            {
//                buildTileCollider = hit.collider;
//                buildTileCollider.tag = "OccupiedPlace";
//                RegisterBuildPlace(buildTileCollider);
//                PlaceTower(hit);
//            }
//        }
//    }

//    private void PlaceTower(RaycastHit2D hit)
//    {
//        if (!EventSystem.current.IsPointerOverGameObject()&& towerButtonRef !=null)
//        {
//            GameObject newTower = Instantiate(towerButtonRef.towerObejct);
//            newTower.transform.position = hit.transform.position;

//            RegisterTower(newTower);
//            DisableDraggedSprite();

//        }
//    }

//    private void RegisterTower(GameObject newTower)
//    {
//        towerList.Add(newTower);
//    }

//    private void RegisterBuildPlace(Collider2D colliderAdd)
//    {
//        buildLits.Add(colliderAdd);
//    }

//    public void selectedTower(TowerButtonScript towerButton)
//    {
//        towerButtonRef = towerButton;
//        enableDraggedSprite(towerButton.draggedSprite);
//    }

//    public void RenameTagsBuildPlace()
//    {
//        foreach (var item in buildLits)
//        {
//            item.tag = "BuldSite";

//        }

//        buildLits.Clear();
//    }


//    void DestroyAllTowers()
//    {
//        foreach (var item in towerList)
//        {
//            Destroy(item);
//        }
//        towerList.Clear();
//    }

//    public void enableDraggedSprite(Sprite  sprite)
//    {
//        towerSprite.enabled = true;
//        towerSprite.sprite = sprite;
//    }

//    public void DisableDraggedSprite()
//    {
//        towerSprite.enabled = false;
//        towerSprite.sprite = null;
//    }
//}
