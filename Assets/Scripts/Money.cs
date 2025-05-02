using UnityEngine;

public class Money : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.TryGetComponent(out Robot _)) 
        {
            Destroy(gameObject);
        }
    }
}
