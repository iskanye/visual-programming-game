using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ConnectionLine : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LineRenderer lineRenderer;

    private OutputConnection outputConnection;
    private InputConnection inputConnection;
    private new PolygonCollider2D collider; //new чтобы vs code не жаловался

    void Awake() 
    {
        collider = gameObject.GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Vector2 start = transform.position; // Обязательно указываю Vector2 чтобы координата z обнулялась
        Vector2 end = inputConnection ? inputConnection.transform.position : Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

        lineRenderer.SetPositions(new[] {(Vector3)start, (Vector3)end}); 

        if (inputConnection)  
        {
            var scaledLine = (end - start) / transform.lossyScale;
            var e = .5f * lineRenderer.widthMultiplier * Vector2.Perpendicular(end - start).normalized / transform.lossyScale; 
            collider.SetPath(0, new Vector2[] {e, scaledLine + e, scaledLine - e, -e});
        }
    }

    /// <summary>
    /// Указать для данной линии её соединения
    /// </summary>
    /// <param name="outputConnection">Выходное соединение</param>
    /// <param name="inputConnection">Входное соединение</param>
    public void SetConnection(OutputConnection outputConnection, InputConnection inputConnection) 
    {
        this.outputConnection = outputConnection;
        this.inputConnection = inputConnection;
        inputConnection.Connect(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy();
    }

    /// <summary>
    /// Уничтожить линию
    /// </summary>
    public void Destroy()
    {
        outputConnection.RemoveConnection(this);
        inputConnection.RemoveConnection(this);
        Destroy(gameObject);        
    }
}