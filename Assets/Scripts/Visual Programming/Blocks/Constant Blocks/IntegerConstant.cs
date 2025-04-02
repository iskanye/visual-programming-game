using System.Collections;

public class IntegerConstant : VariableBlock
{
    protected override object Variable => constant;     
    
    private int constant;

    public void ChangeInteger(string var) 
    {
        constant = System.Convert.ToInt32(var);
    }
}