using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimation : MonoBehaviour
{
    [SerializeField] private Transform syncIcon;
 

    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private bool clockWise ;

    void Update()
    {
        Spin(syncIcon);
       
    }

    void Spin(Transform obj)
    {
        if (obj != null)
        {
            obj.Rotate(Vector3.forward *(clockWise?1:-1), rotationSpeed * Time.deltaTime);
        }
    }
}
