using System.Collections;

public class StartBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        output[0].Output(null);
        yield return null;
    }
}