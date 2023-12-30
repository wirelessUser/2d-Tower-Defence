using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAnimation : MonoBehaviour
{
    [SerializeField] private Transform flippedObject;
    [SerializeField] private float elapsedTime = 0f;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float flipSpeed = 180f;
    [SerializeField] private bool flipVerticle;
    [SerializeField] private bool flipOpposite;

    void Start()
    {
       
        Flip(flippedObject);
    }

    void Flip(Transform obj)
    {
        if (obj != null)
        {
            StartCoroutine(FlipCoroutine(obj));
        }
    }

       IEnumerator FlipCoroutine(Transform obj)
    {

            duration = 3.0f; 
        while (elapsedTime < duration)
        {
            Vector3 flipHorVerticle = flipVerticle ? Vector3.left:Vector3.up;
            obj.Rotate(flipHorVerticle * (flipOpposite ? 1:-1), flipSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.rotation = Quaternion.identity; // Reset to the original rotation after flipping
    }
}
