using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData e)
    {
        Camera.main.transform.position -= (Vector3)e.delta / 200; 
    }
}
