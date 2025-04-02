using UnityEngine;
using System.Collections;

public class ConstantBlock : Block
{
    protected virtual object Variable { get; }

    private Coroutine coroutine;

    /// <summary>
    /// Начать передавать данные константы
    /// </summary>
    public void StartEmitting() 
    {
        coroutine = StartCoroutine(Process(null));
    }

    /// <summary>
    /// Перестать передавать данные константы
    /// </summary>
    public void StopEmitting()
    {
        StopCoroutine(coroutine);
    }

    public override IEnumerator Process(object[] data)
    {
        while (true)    
        {
            output[0].Output(Variable);
            yield return null;
        }
    }
}