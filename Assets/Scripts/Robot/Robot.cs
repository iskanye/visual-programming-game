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

    public bool Move(Vector3 dir)
    {    
        direction = dir.normalized;

        if (WallInFront) 
        {
            return false;
        }

        IEnumerator _Move()
        {
            var startPos = transform.position;
            float t = 0;
            moving = true;
            while (transform.position != startPos + dir) 
            {
                transform.position = Vector3.Lerp(startPos, startPos + dir, t);
                t += speed * Time.deltaTime;
                yield return null;
            }
            moving = false;
        }

        StartCoroutine(_Move());
        return true;
    }
}
