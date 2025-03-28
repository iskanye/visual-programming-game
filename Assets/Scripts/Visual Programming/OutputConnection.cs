using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutputConnection : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    /// <summary>
    /// Блок данного выхода
    /// </summary>
    public Block Block { get => block; }
    /// <summary>
    /// Состояние готовности данного выхода
    /// </summary>
    public bool Ready { get => connections.Count != 0;}

    [SerializeField] private Block block;
    [SerializeField] private ConnectionLine connectionLinePrefab;

    private List<ConnectionLine> connections = new();
    private ConnectionLine currentLine;

    /// <summary>
    /// Удалить конкретное соединение данного выхода
    /// </summary>
    /// <param name="line">Объект линии соединения</param>
    public void RemoveConnection(ConnectionLine line)
    {
        connections.Remove(line);
    }

    /// <summary>
    /// Уничножить выход
    /// </summary>
    public void Destroy()
    {
        connections.ForEach(i => i.Destroy());
    }

    /// <summary>
    /// Подать данные на данный выход
    /// </summary>
    /// <param name="data">Данные</param>
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
            currentLine.SetConnection(this, input);
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
