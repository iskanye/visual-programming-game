using System.Collections;
using UnityEngine;

public class MoveBlock : Block
{
    [SerializeField] private Vector3 direction;

    public override IEnumerator Process(object[] data)
    {
        if (!Blueprint.Current.Robot.Move(direction)) 
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