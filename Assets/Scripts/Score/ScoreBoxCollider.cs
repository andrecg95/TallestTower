using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreBoxCollider : MonoBehaviour
{
    public event Action OnEnter, OnExit, OnStay;

    int _inObjectsCount;


    void OnTriggerEnter2D(Collider2D collision)
    {
        ++_inObjectsCount;

        if (!IsPlacedPiece(collision))
            return;

        OnEnter?.Invoke();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        --_inObjectsCount;

        if (!IsPlacedPiece(collision))
            return;

        if(_inObjectsCount == 0)
            OnExit?.Invoke();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!IsPlacedPiece(collision))
            return;

        OnStay?.Invoke();
    }

    bool IsPlacedPiece(Collider2D collision)
    {
        return collision.TryGetComponent(out Piece piece) && piece.IsPlaced();
    }
}
