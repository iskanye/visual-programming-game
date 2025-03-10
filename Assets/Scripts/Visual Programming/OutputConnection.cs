using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutputConnection : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Block Block { get => block; }

    [SerializeField] private Canvas canvas;
    [SerializeField] private Block block;
    [SerializeField] private ConnectionLine connectionLinePrefab;

    private List<ConnectionLine> connections = new();

    private ConnectionLine currentLine;

    public void Output(object data)
    {
        connections.ForEach(i => i.TransferData(data));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentLine = Instantiate(connectionLinePrefab, transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject && eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out InputConnection input)
            && input.Block != block && !input.Connected)
        {
            connections.Add(currentLine);
            currentLine.SetConnection(input);
        }
        else 
        {
            Destroy(currentLine.gameObject);
        }

        currentLine = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Просто чтобы Block не перехватил OnDrag
    }
}
