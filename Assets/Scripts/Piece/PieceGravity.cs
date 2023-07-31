using UnityEngine;

public class PieceGravity : MonoBehaviour
{
    public float gravity = 1;


    void Update()
    {
        transform.position += gravity * Time.deltaTime * Vector3.down * 3;
    }
}
