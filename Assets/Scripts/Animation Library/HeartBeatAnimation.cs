using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartBeatAnimation : MonoBehaviour
{
    public Image[] heartAnimationObject;
    public float repeatRate = 1f;
    public float beatDuration = 0.5f;
    public float beatScale = 1.0f;

    void Start()
    {
        InvokeRepeating("Heartbeat", 0f, repeatRate);
    }

    void Heartbeat()
    {
        foreach (Image heart in heartAnimationObject)
        {
            StartCoroutine(PulseHeart(heart));
        }
    }

    IEnumerator PulseHeart(Image heart)
    {
        float duration = beatDuration;
        float scale = beatScale;

        // Check if the heart has a different tag
        if (heart.CompareTag("FaBeatHeart"))
        {
            // Adjust the duration and scale for heartAnimationObject with the "FaBeatHeart" tag
            duration = 2.0f;
            scale = 2.0f;
        }

        float t = 0f;
        Vector3 originalScale = heart.rectTransform.localScale;

        while (t < duration)
        {
            t += Time.deltaTime;
            float factor = t / duration;
            heart.rectTransform.localScale = Vector3.Lerp(originalScale, originalScale * scale, factor);
            yield return null;
        }

        // Reset the scale after the pulse
        heart.rectTransform.localScale = originalScale;
    }
}
