using UnityEngine;

public class Blueprint : MonoBehaviour
{
    public float Delay { get => delay; }
    public float ScaleFactor { get => canvas.scaleFactor; }
    public Robot Robot { get => robot; }

    [SerializeField] private Canvas canvas; 
    [SerializeField] private StartBlock startBlock;
    [SerializeField] private Robot robot;    
    [SerializeField] private float delay = .25f;

    private bool isExecuting;

    public void StartBlueprint()
    {
        if (isExecuting) 
        {
            return;
        }
        isExecuting = true;
        StartCoroutine(startBlock.Process(null));
    }

    public void EndExecuting() 
    {
        isExecuting = false;
    }
}