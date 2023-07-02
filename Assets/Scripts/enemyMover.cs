using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    public Transform[] wayPoints;

    public float timeToTravel;
    public int waypointCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToTravel += Time.deltaTime;
        //if (transform.position.y<wayPoints[waypointCount].transform.position.y && transform.position.x < wayPoints[waypointCount].transform.position.x)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointCount].transform.position, timeToTravel);
        //}
        if (waypointCount<wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointCount].transform.position, timeToTravel*0.005f);
        }

        if (waypointCount==17)
        {
            waypointCount = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("trigerring");
        if (collision.gameObject.tag == "WayPoint")
        {
            waypointCount++;
        }
    }
}
