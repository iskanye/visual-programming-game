using UnityEngine;

public class StartBlock : Block
{
    public override void Process(object[] data)
    {
        output[0].Output(null);
    }
}