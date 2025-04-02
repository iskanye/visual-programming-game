using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public bool IsMoving { get => moving; }
    public bool WallInFront 
    { 
        get 
        {
            var collider = Physics2D.OverlapCircle(transform.position, 1);
            if (collider)
            {
                var dir = (collider.transform.position - transform.position).normalized;
                return collider && Mathf.Acos(Vector2.Dot(dir, direction)) * Mathf.Rad2Deg < 45;
            }
            return false;
        }
    }

    [SerializeField] private float speed;

    private bool moving;
    private Vector2 direction;

    public void Move(Vector3 dir)
    {    
        direction = dir.normalized;

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
    }
}
