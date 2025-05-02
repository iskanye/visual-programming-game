using UnityEngine;
using System.Collections;

public class RotateBlock : Block
{
    public bool Clockwise { set => clockwise = value; }

    [SerializeField] private bool clockwise;

    public override IEnumerator Process(object[] data)
    {
        Blueprint.Current.Robot.Rotate(clockwise);
        
        yield return base.Process(null);
        output[0].Output(null);
    }
}
