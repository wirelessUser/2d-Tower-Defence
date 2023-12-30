using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    public Transform[] wayPoints;

    public float timeToTravel;
    public int waypointCount;
    public float speedMultiplier ;

    // Update is called once per frame
    void Update()
    {
      //  timeToTravel += Time.deltaTime;
     
        if (waypointCount<wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointCount].transform.position, timeToTravel* speedMultiplier);
        }

        if (waypointCount== wayPoints.Length-1)
        {
            waypointCount = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "WayPoint")
        {
            waypointCount++;
        }
    }
}
