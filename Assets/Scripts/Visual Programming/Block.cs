using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private OutputConnection[] output;
    [SerializeField] private InputConnection[] input;

    void Update() 
    {
        if (input.All(i => i.Ready)) 
        {
            Process(input.Select(i => i.Data).ToArray());
        }
    }

    public virtual void Process(object[] data) { }

    // Перемещение блока
    public void OnDrag(PointerEventData eventData)
    {
        (transform as RectTransform).anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
