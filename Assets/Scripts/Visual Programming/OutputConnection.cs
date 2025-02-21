using UnityEngine;
using UnityEngine.EventSystems;

public class OutputConnection : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private LineRenderer connectionPrefab;
    private LineRenderer currentConnetion;

    public void OnBeginDrag(PointerEventData eventData)
    {        
        currentConnetion = Instantiate(connectionPrefab, transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pos = Camera.main.ScreenToWorldPoint(eventData.position) - transform.position;
        var scale = transform.lossyScale;
        currentConnetion.SetPositions(new[] {Vector3.zero, new Vector3(pos.x / scale.x, pos.y / scale.y, 0)});
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
}
