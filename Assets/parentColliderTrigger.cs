using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentColliderTrigger : MonoBehaviour
{
    public EnemyTargetting refTargetting;

    private void Awake()
    {
        refTargetting = GetComponentInChildren<EnemyTargetting>();
            
     }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Callling triger");
        if (collision.gameObject.tag == "Enemy")
        {
            refTargetting.shootOrNot = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            refTargetting.shootOrNot = false;
        }
    }
}
