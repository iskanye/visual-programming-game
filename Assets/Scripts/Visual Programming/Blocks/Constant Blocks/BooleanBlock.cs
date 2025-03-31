using System.Collections;

public class BooleanBlock : ConstantBlock
{
    protected override object Variable => constant;     
    
    [UnityEngine.SerializeField] private bool constant;

    public void ChangeBool(bool var) 
    {
        constant = var;
    }
}