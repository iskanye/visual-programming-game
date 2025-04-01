using System.Collections;
using UnityEngine;

public class MoveBlock : Block
{
    [SerializeField] private Vector3Int direction;

    public override IEnumerator Process(object[] data)
    {
        Blueprint.Current.Robot.Move(direction);
        yield return base.Process(null);
        output[0].Output(null);
    }
}