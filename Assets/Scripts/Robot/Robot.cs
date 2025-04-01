using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public bool IsMoving { get => moving; }

    [SerializeField] private float speed;

    private bool moving;

    public void Move(Vector3Int dir)
    {
        var startPos = transform.position;
        float t = 0;
        
        IEnumerator _Move()
        {
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
