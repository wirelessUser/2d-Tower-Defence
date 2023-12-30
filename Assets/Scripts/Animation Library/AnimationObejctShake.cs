using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationObejctShake : MonoBehaviour
{
    [SerializeField] private  Transform[] ObjectToShakeList;
   [SerializeField] private float shakeDuration ;
    [SerializeField] private  float shakeIntensity ;
    [SerializeField] private float repeatRate = 1f;
    void Start()
    {
       // InvokeRepeating("Shake", 1f, repeatRate);
        StartCoroutine(ShakeCoroutine(ObjectToShakeList[0]));

    }

    void Shake()
    {
        foreach (Transform heart in ObjectToShakeList)
        {
            StartCoroutine(ShakeCoroutine(heart));
        }
    }

    IEnumerator ShakeCoroutine(Transform obj)
    {
        Vector3 originalPosition = obj.position;
     

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float xOffset = Random.Range(-1f, 1f) * shakeIntensity;
            float yOffset = Random.Range(-1f, 1f) * shakeIntensity;

            obj.position = originalPosition + new Vector3(xOffset, yOffset, 0f);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        StartCoroutine(ShakeCoroutine(ObjectToShakeList[0]));
        obj.position = originalPosition; // Reset to the original position after shaking
    }
}
