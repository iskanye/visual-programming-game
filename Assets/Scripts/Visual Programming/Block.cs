using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IDragHandler
{
    [SerializeField] protected Blueprint blueprint;
    [SerializeField] protected OutputConnection[] output;
    [SerializeField] protected InputConnection[] input;

    void Update() 
    {
        if (input.Length != 0 && input.All(i => i.Ready)) 
        {
            StartCoroutine(Process(input.Select(i => i.Data).ToArray()));
        }
    }

    void OnDestroy()
    {
        foreach (var i in input) 
        {
            i.Destroy();
        }
        foreach (var i in output) 
        {
            i.Destroy();
        }
    }

    public virtual IEnumerator Process(object[] data) 
    { 
        yield return new WaitForSeconds(blueprint.Delay);
    }

    // Перемещение блока
    public void OnDrag(PointerEventData eventData)
    {
        (transform as RectTransform).anchoredPosition += eventData.delta / blueprint.ScaleFactor;
    }
}
