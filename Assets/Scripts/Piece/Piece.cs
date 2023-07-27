using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Piece : MonoBehaviour
{
    public event Action OnPlaced;

    Transform _transform;
    Rigidbody2D _rigidbody2D;
    CompositeCollider2D _collider;


    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CompositeCollider2D>();
    }

    public void Move(float x)
    {
        
    }

    public void Rotate()
    {

    }

    void Place()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _collider.isTrigger = false;

        if (TryGetComponent(out PieceGravity pieceGravity))
        {
            pieceGravity.enabled = false;
        }

        OnPlaced?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Place();
    }
}
