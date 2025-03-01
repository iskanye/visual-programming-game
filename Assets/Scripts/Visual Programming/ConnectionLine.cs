using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConnectionLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    private InputConnection inputConnection;

    void Update()
    {
        if (inputConnection)
        {
            lineRenderer.SetPositions(new[] {transform.position, inputConnection.transform.position});
        }
        else 
        {
            lineRenderer.SetPositions(new[] {transform.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.value)});
        }
    }

    public void SetConnection(InputConnection inputConnection) 
    {
        this.inputConnection = inputConnection;
    }

    public void TransferData(object data) 
    {
        inputConnection.Data = data;
    }
}