using System.Collections;

public class EndBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        blueprint.EndExecuting();
        yield break;
    }
}