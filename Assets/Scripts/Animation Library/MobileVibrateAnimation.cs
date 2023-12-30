using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileVibrateAnimation : MonoBehaviour
{
    [SerializeField] private float vibrationSpeed = 10f;
    [SerializeField] private float vibrationAmount = 0.1f;

    void Update()
    {
        ApplyVibration();
    }

    void ApplyVibration()
    {
        float vibrationOffsetX = Mathf.Sin(Time.time * vibrationSpeed) * vibrationAmount;
        float vibrationOffsetY = Mathf.Cos(Time.time * vibrationSpeed) * vibrationAmount;

        transform.localPosition = new Vector3(transform.localPosition.x+vibrationOffsetX, transform.localPosition.y+vibrationOffsetY, 0f);
    }
}
