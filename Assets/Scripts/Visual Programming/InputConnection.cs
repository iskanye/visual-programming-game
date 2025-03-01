using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputConnection : MonoBehaviour
{
    public Block Block { get => block; }
    public bool Ready { get => data != null; }
    public object Data { get => data; set => data = value; }

    [SerializeField] private Block block;

    private object data = null;
}
