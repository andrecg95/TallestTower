using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyerBoundary : MonoBehaviour
{
    Collider2D _collider;


    void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 boundPointUL = collision.bounds.center - collision.bounds.extents;
        Vector2 boundPointBR = collision.bounds.center + collision.bounds.extents;

        if (_collider.bounds.Contains(boundPointUL) && _collider.bounds.Contains(boundPointBR))
            Destroy(collision.gameObject);
    }
}
