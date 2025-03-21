using UnityEngine;

public class Robot : MonoBehaviour
{
    public void Move(Vector3Int dir)
    {
        transform.position += (Vector3)dir;
    }
}
