using System.Collections.Generic;
using UnityEngine;

public class InputConnection : MonoBehaviour
{
    /// <summary>
    /// Блок данного входа
    /// </summary>
    public Block Block { get => block; }
    /// <summary>
    /// Состояние готовности входа (Подали ли на него данные)
    /// </summary>
    public bool Ready { get => ready; }
    /// <summary>
    /// Данные, подданные на данный вход
    /// </summary>
    public object Data 
    { 
        get
        {
            ready = false;
            return data;
        }
        set 
        {
            data = value;
            ready = true;
        }
    }
    /// <summary>
    /// Подсоединён ли какой-либо блок к данному входу?
    /// </summary>
    public bool Connected { get => lines.Count != 0; }

    [SerializeField] private Block block;

    private object data;
    private bool ready;
    private List<ConnectionLine> lines = new();

    /// <summary>
    /// Подсоединить блок к данному входу
    /// </summary>
    /// <param name="line">Объект линии соединения</param>
    public void Connect(ConnectionLine line)
    {
        lines.Add(line);
    }

    /// <summary>
    /// Удалить соединение
    /// </summary>
    public void RemoveConnection(ConnectionLine line)
    {
        lines.Remove(line);
    }

    /// <summary>
    /// Уничтожить вход
    /// </summary>
    public void Destroy()
    {
        lines.ForEach(i => i.Destroy());
    }
}
