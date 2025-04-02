using UnityEngine;
using System.Collections;
using System;

public class VariableBlock : Block
{
    /// <summary>
    /// Доступные типы для блоков переменных
    /// </summary>
    public static Type[] AllowedTypes 
    {
        get => new Type[] {typeof(bool), typeof(int), typeof(float), typeof(Vector2)};
    }

    protected virtual object Variable { get; }

    private Coroutine coroutine;

    /// <summary>
    /// Начать передавать данные переменной
    /// </summary>
    public void StartEmitting() 
    {
        coroutine = StartCoroutine(Process(null));
    }

    /// <summary>
    /// Перестать передавать данные переменной
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