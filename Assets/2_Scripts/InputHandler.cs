using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnClickPressed;
    [SerializeField] private UnityEvent OnClickReleased;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) OnClickPressed?.Invoke();
        if(Input.GetMouseButtonUp(0)) OnClickReleased?.Invoke();
    }

    public static Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static RaycastHit2D WhatUnderCursorByLayer(LayerMask mask)
    {
        return Physics2D.Raycast(GetMouseWorldPosition(), Vector3.back, 10f, mask);
    }
}
