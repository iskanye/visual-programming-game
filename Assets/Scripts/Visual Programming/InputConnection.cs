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
        get => data; 
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

    public void Connect()
    {
        connected = true;
    }

    public void RemoveConnection()
    {
        connected = false;
    }
}
