using UnityEngine;

public class PieceGravity : MonoBehaviour
{
    Transform _transform;
    public float gravity = 1;


    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.position += gravity * Time.deltaTime * Vector3.down;
    }
}
