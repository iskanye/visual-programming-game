using System.Collections;

public class MoveBlock : Block
{
    public override IEnumerator Process(object[] data)
    {
        if (!Blueprint.Current.Robot.Move())
        {
            Blueprint.Current.ErrorMessage("Невозможно пройти через препятствие", gameObject);
            yield break;
        }

        while (Blueprint.Current.Robot.IsMoving) 
        {
            yield return null;
        }
        
        yield return base.Process(null);
        output[0].Output(null);
    }
}