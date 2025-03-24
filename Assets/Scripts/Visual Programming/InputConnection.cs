using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputConnection : MonoBehaviour
{
    public Block Block { get => block; }
    public bool Ready { get => ready; }
    public object Data 
    { 
        get
        {
            ready = false;
            return data;
        }
        set 
        {
            data = value;
            ready = true;
        }
    }
    public bool Connected { get => connected; }

    [SerializeField] private Block block;

    private object data;
    private bool ready;
    private bool connected;
    private ConnectionLine line;

    public void Connect(ConnectionLine line)
    {
        connected = true;
        this.line = line;
    }

    public void RemoveConnection()
    {
        connected = false;
    }

    public void Destroy()
    {
        line.Destroy();
    }
}
