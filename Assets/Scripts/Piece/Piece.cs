using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Piece : MonoBehaviour
{
    public event Action<Piece> OnPlaced;
    public event Action<Piece> OnDestroyed;

    Rigidbody2D _rigidbody2D;
    CompositeCollider2D _collider;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CompositeCollider2D>();
    }

    void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    void Place()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _collider.isTrigger = false;

        if (TryGetComponent(out PieceGravity pieceGravity))
            pieceGravity.enabled = false;

        if (TryGetComponent(out PieceMovement pieceMovement))
            pieceMovement.enabled = false;

        OnPlaced?.Invoke(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Place();
    }

    public bool IsPlaced()
    {
        return _rigidbody2D.bodyType == RigidbodyType2D.Dynamic;
    }
}
