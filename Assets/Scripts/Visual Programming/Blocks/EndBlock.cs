using System.Collections;

public class EndBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        Blueprint.Current.EndExecuting();
        yield break;
    }
}