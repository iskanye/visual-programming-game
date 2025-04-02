using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public bool IsMoving { get => moving; }
    public bool WallInFront 
    { 
        get 
        {
            var collider = Physics2D.OverlapCircle(transform.position, seeRange, obstacleLayer);
            if (collider)
            {
                var dir = (collider.transform.position - transform.position).normalized;
                return Mathf.Acos(Vector2.Dot(dir, direction)) * Mathf.Rad2Deg < seeAngle;
            }
            return false;
        }
    }

    [SerializeField] private float speed;
    [SerializeField] private float seeRange = 1;
    [SerializeField] [Range(0, 180)] private float seeAngle = 90;
    [SerializeField] private LayerMask obstacleLayer;

    private bool moving;
    private Vector2 direction = Vector2.up;

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
