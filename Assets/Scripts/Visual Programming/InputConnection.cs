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

    [SerializeField] private Block block;

    private object data;
    private bool ready;
}
