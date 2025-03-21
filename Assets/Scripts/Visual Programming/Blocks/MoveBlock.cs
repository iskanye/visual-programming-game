using System.Collections;
using UnityEngine;

public class MoveBlock : Block
{
    [SerializeField] private Vector3Int direction;

    public override IEnumerator Process(object[] data)
    {
        blueprint.Robot.Move(direction);
        yield return base.Process(data);
        output[0].Output(null);
    }
}