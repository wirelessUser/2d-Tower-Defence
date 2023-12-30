using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleAnimation : MonoBehaviour
{
    [SerializeField] private float wobbleSpeed = 2f;
    [SerializeField] private float wobbleAmount = 10f;

    private void Start()
    {
        StartWobble();
    }

    private void StartWobble()
    {
        StartCoroutine(WobbleCoroutine());
    }

    private System.Collections.IEnumerator WobbleCoroutine()
    {
        Vector3 originalRotation = transform.eulerAngles;
        float elapsedTime = 0f;

        while (true)
        {
            float wobbleOffset = Mathf.Sin(elapsedTime * wobbleSpeed) * wobbleAmount;
            transform.eulerAngles = originalRotation + new Vector3(0f, 0f, wobbleOffset);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
