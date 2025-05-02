using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public bool IsMoving { get => moving; }
    public bool WallInFront 
    { 
        get 
        {
            var collider = Physics2D.OverlapCircle((Vector2)transform.position + .5f * direction, .4f, obstacleLayer);
            return collider;
        }
    }

    [SerializeField] private float speed;
    [SerializeField] private LayerMask obstacleLayer;

    private bool moving;
    private Vector2 direction = Vector2.up;

    public bool Move()
    {    
        if (WallInFront) 
        {
            return false;
        }

        IEnumerator _Move()
        {
            Vector2 startPos = transform.position;
            float t = 0;
            moving = true;
            while ((Vector2)transform.position != startPos + direction) 
            {
                transform.position = Vector2.Lerp(startPos, startPos + direction, t);
                t += speed * Time.deltaTime;
                yield return null;
            }
            moving = false;
        }

        StartCoroutine(_Move());
        return true;
    }

    public void Rotate(bool clockwise)
    {
        direction = new Vector2(
            (clockwise ? 1 : -1) * direction.y,
            (clockwise ? -1 : 1) * direction.x);
    }
}
