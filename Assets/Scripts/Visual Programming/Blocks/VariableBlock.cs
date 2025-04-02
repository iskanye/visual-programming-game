using UnityEngine;
using System.Collections;
using System;

public class VariableBlock : Block
{
    /// <summary>
    /// Доступные типы для блоков переменных
    /// </summary>
    public static readonly Type[] AllowedTypes = 
    {
        typeof(bool), typeof(int), typeof(float), typeof(Vector2)
    };

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