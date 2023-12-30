using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleAnimation : MonoBehaviour
{
    [SerializeField] private float wiggleSpeed = 5f;
    [SerializeField] private float wiggleAmount = 0.1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        ApplyWiggle();
    }

    void ApplyWiggle()
    {
        float wiggleOffsetX = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount;
        float wiggleOffsetY = Mathf.Cos(Time.time * wiggleSpeed) * wiggleAmount;

        transform.position = originalPosition + new Vector3(wiggleOffsetX, wiggleOffsetY, 0f);
    }
}
