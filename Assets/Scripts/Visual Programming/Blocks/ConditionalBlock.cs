using System.Collections;

public class ConditionalBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        if ((bool)data[1])
        {
            output[0].Output(data[0]);
        }
        else 
        {
            output[1].Output(data[0]);
        }
        yield break;
    }
}