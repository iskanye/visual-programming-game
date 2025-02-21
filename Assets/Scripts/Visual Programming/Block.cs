using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private OutputConnection[] output;

    // Перемещение блока
    public void OnDrag(PointerEventData eventData)
    {
        (transform as RectTransform).anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
