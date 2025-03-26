using System.Collections;

public class BooleanBlock : ConstantBlock
{
    protected override object Variable => constant;     
    
    [UnityEngine.SerializeField] private bool constant;
}