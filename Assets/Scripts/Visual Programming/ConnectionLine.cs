using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnectionLine : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image image;

    private OutputConnection outputConnection;
    private InputConnection inputConnection;
    
    public void CreateLine(Vector2 pos1, Vector2 pos2)
    {
        Vector2 midpoint = (pos2 + pos1) / 2f;

        (image.transform as RectTransform).position = midpoint;

        Vector2 dir = pos2 - pos1;
        (image.transform as RectTransform).rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        (image.transform as RectTransform).localScale = new Vector3(dir.magnitude, 1f, 1f);
    }

    void Update()
    {
        Vector2 start = transform.position; // Обязательно указываю Vector2 чтобы координата z обнулялась
        Vector2 end = inputConnection ? inputConnection.transform.position : Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

        CreateLine(start, end); 
    }

    /// <summary>
    /// Указать для данной линии её соединения
    /// </summary>
    /// <param name="outputConnection">Выходное соединение</param>
    /// <param name="inputConnection">Входное соединение</param>
    public void SetConnection(OutputConnection outputConnection, InputConnection inputConnection) 
    {
        this.outputConnection = outputConnection;
        this.inputConnection = inputConnection;
        inputConnection.Connect(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy();
    }

    /// <summary>
    /// Уничтожить линию
    /// </summary>
    public void Destroy()
    {
        outputConnection.RemoveConnection(this);
        inputConnection.RemoveConnection(this);
        Destroy(gameObject);        
    }
}