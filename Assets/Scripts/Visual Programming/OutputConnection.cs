using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutputConnection : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Block Block { get => block; }

    [SerializeField] private Canvas canvas;
    [SerializeField] private Block block;
    [SerializeField] private LineRenderer connectionLinePrefab;

    private List<InputConnection> connections = new();
    private List<LineRenderer> lines = new();

    private LineRenderer currentLine;
    private Vector2 delta;

    void Update()
    {
        for (int i = 0; i < lines.Count; i++) 
        {            
            lines[i].SetPositions(new[] {transform.position, connections[i].transform.position});
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {        
        delta = Vector2.zero;
        currentLine = Instantiate(connectionLinePrefab, transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        delta += eventData.delta / canvas.scaleFactor;
        currentLine.SetPositions(new[] {Vector3.zero, (Vector3)delta});
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        currentLine.useWorldSpace = true;
        lines.Add(currentLine);
        currentLine = null;
    }

    /// <summary>
    /// Добавить соединение к блоку
    /// </summary>
    public void Connect(InputConnection input)
    {
        connections.Add(input);
    }
}
