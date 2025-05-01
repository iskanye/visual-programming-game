using UnityEngine;

public class Money : MonoBehaviour
{
    public int Amount { set => amount = value; }

    [SerializeField] private int amount = 1;
}
