using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _yawTransform;
    [SerializeField] private Transform _pitchTransform;
    private void Update()
    {
        var delta = GetTouchInputDeltaPoistion();
        if (delta == Vector2.zero) return;
        _yawTransform.Rotate(Vector3.up, delta.x);
        _pitchTransform.Rotate(_yawTransform.right, -delta.y);

    }
    private Vector2 GetTouchInputDeltaPoistion()
    {
        if (Input.touchCount != 2) return Vector2.zero;
        Debug.Log("Rotating");
        return (Input.GetTouch(0).deltaPosition + Input.GetTouch(1).deltaPosition) * .5f;
    }
}
