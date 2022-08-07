using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _touchPos;
    public Vector2 Direction { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = Direction = eventData.position - _touchPos;
        Direction = delta.normalized;
    }
}