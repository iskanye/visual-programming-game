using System.Collections;

public class BooleanBlock : ConstantBlock
{
    protected override object Variable => constant;     
    
    private bool constant;

    public void ChangeBool(bool var) 
    {
        constant = var;
    }
}