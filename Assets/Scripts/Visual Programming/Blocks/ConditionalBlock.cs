using System.Collections;

public class ConditionalBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        if (data[1] is not bool) 
        {
            Blueprint.Current.ErrorMessage("Невозможно преобразовать к логическому типу", gameObject);
            yield break;
        }

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