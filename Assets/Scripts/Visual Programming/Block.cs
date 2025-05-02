using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Базовый класс блока
/// </summary>
public class Block : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    /// <summary>
    /// Состояние готовности блока к выполнению
    /// </summary>
    public bool Ready { get => output.All(i => i.Ready) && input.All(i => i.Connected); }

    [SerializeField] protected OutputConnection[] output;
    [SerializeField] protected InputConnection[] input;

    void Update() 
    {
        if (input.Length != 0 && input.All(i => i.Ready)) 
        {
            Blueprint.Current.StartCoroutine(Process(input.Select(i => i.Data).ToArray()));
        }
    }

    /// <summary>
    /// Уничтожить блок и все его соединения
    /// </summary>
    public void Destroy()
    {
        foreach (var i in input) 
        {
            i.Destroy();
        }
        foreach (var i in output) 
        {
            i.Destroy();
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// Основная функция блока
    /// </summary>
    /// <param name="data">Входные данные</param>
    public virtual IEnumerator Process(object[] data) 
    { 
        yield return new WaitForSeconds(Blueprint.Current.Delay);
    }

    // Перемещение блока
    public void OnDrag(PointerEventData e)
    {
        (transform as RectTransform).anchoredPosition += e.delta / Blueprint.Current.ScaleFactor;
    }

    // Нажатие по блоку
    public virtual void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Right) 
        {
            Destroy();
        }
    }
}
