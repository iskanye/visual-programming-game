using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputConnection : MonoBehaviour, IDropHandler
{
    public Block Block { get => block; }

    [SerializeField] private Block block;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<OutputConnection>().Connect(this);
    }
}
