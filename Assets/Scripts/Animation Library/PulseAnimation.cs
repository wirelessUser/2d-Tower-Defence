using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAnimation : MonoBehaviour
{
    [SerializeField] private float pulseScale = 1.5f;
    [SerializeField] private float pulseDuration = 1f;

    void Start()
    {
        StartCoroutine(PulseCoroutine());
    }

    IEnumerator PulseCoroutine()
    {
        Vector3 originalScale = transform.localScale;
        float elapsedTime = 0f;

        while (true)
        {
            while (elapsedTime < pulseDuration)
            {
                transform.localScale = Vector3.Lerp(originalScale, originalScale * pulseScale, elapsedTime / pulseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;

            while (elapsedTime < pulseDuration)
            {
                transform.localScale = Vector3.Lerp(originalScale * pulseScale, originalScale, elapsedTime / pulseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;
        }
    }
}
