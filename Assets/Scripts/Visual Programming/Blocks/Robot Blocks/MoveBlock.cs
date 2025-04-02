using System.Collections;
using UnityEngine;

public class MoveBlock : Block
{
    [SerializeField] private Vector3 direction;

    public override IEnumerator Process(object[] data)
    {
        Blueprint.Current.Robot.Move(direction);
        while (Blueprint.Current.Robot.IsMoving) 
        {
            yield return null;
        }
        
        yield return base.Process(null);
        output[0].Output(null);
    }
}