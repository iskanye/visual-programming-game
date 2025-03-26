using UnityEngine;
using System.Collections;

public class ConstantBlock : Block
{
    protected virtual object Variable { get; }

    public override IEnumerator Process(object[] data)
    {
        output[0].Output(Variable);
        yield break;
    }
}