using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingAvatarView : View, IDragHandler {
    public event Action<Vector2> DragEvent;
    public void OnDrag(PointerEventData eventData) {
        Vector2 delta = eventData.delta;
        DragEvent?.Invoke(delta);
    }
}
