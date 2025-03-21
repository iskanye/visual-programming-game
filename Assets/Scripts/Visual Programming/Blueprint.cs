using UnityEngine;

public class Blueprint : MonoBehaviour
{
    public float ScaleFactor { get => canvas.scaleFactor; }
    [SerializeField] private Canvas canvas; 
    [SerializeField] private StartBlock startBlock; 
}