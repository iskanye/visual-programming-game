using System.Linq;
using System.Collections;
using UnityEngine;
using TMPro;

public class Blueprint : MonoBehaviour
{
    /// <summary>
    /// Текущий экземпляр схемы
    /// </summary>
    public static Blueprint Current { get; private set; }
    public float Delay { get => delay; }
    public float ScaleFactor { get => canvas.scaleFactor; }
    public Robot Robot { get => robot; }

    [SerializeField] private Canvas canvas; 
    [SerializeField] private StartBlock startBlock;
    [SerializeField] private Robot robot;    
    [SerializeField] private float delay = .25f;
    [SerializeField] private TMP_Text messageText;

    private Block[] blocks;
    private bool isExecuting;

    void Awake()
    {
        Current = this;
    }

    public void StartBlueprint()
    {
        if (isExecuting) 
        {
            ErrorMessage("Схема уже выполняется", null);
            return;
        }

        blocks = GetComponentsInChildren<Block>();
        if (blocks.Any(i => !i.Ready)) 
        {
            ErrorMessage("Не все блоки соединены", null);
            return;
        }

        isExecuting = true;
        
        foreach (var i in blocks.Where(i => i is ConstantBlock)) 
        {
            (i as ConstantBlock).StartEmitting();
        }
        StartCoroutine(startBlock.Process(null));
    }

    public void EndExecuting() 
    {
        foreach (var i in blocks.Where(i => i is ConstantBlock)) 
        {
            (i as ConstantBlock).StopEmitting();
        }
        isExecuting = false;
    }

    /// <summary>
    /// Вывести сообщение на экран
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    public void Message(string message, GameObject sender) 
    {
        IEnumerator _Message() 
        {
            messageText.text = message;
            yield return new WaitForSeconds(3f);
            messageText.text = "";
        }
        StartCoroutine(_Message());
    }

    /// <summary>
    /// Вывести сообщение об ошибке
    /// </summary>
    /// <param name="message">Описание ошибки</param>
    public void ErrorMessage(string message, GameObject sender) => Message("Ошибка: " + message, sender);
}