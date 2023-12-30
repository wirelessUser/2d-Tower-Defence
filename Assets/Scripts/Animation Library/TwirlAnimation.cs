using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwirlAnimation : MonoBehaviour
{
    [SerializeField] private float popScale = 1.5f;
    [SerializeField] private float popDuration = 0.5f;

    void Start()
    {
        StartCoroutine(PopCoroutine());
    }

    IEnumerator PopCoroutine()
    {
        Vector3 originalScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < popDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, originalScale * popScale, elapsedTime / popDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale* popScale; // Reset to the original scale
        //StartCoroutine(PopCoroutine());
    }
}
