using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreBoxCollider m_TopBox, m_BottomBox;

    Coroutine _moveDown, _moveUp;
    float _moveSpeed = 10;


    void OnEnable()
    {
        m_TopBox.OnStay += StartMoveUp;
        m_TopBox.OnExit += StopMoveUp;
        m_BottomBox.OnEnter += StopMoveDown;
        m_BottomBox.OnExit += StartMoveDown;
    }

    void OnDisable()
    {
        m_TopBox.OnEnter -= StartMoveUp;
        m_TopBox.OnExit -= StopMoveUp;
        m_BottomBox.OnEnter -= StopMoveDown;
        m_BottomBox.OnExit -= StartMoveDown;
    }

    public int GetScore()
    {
        return (int) transform.position.y;
    }

    IEnumerator MoveUp()
    {
        while (true)
        {
            if (_moveDown == null)
                transform.Translate(Time.deltaTime * _moveSpeed * Vector3.up);
            yield return null;
        }
    }

    IEnumerator MoveDown()
    {
        while (true)
        {
            transform.Translate(Time.deltaTime * _moveSpeed * Vector3.down);
            yield return null;
        }
    }

    void StartMoveDown()
    {
        if (_moveDown == null) 
            _moveDown = StartCoroutine(MoveDown());
    }

    void StopMoveDown()
    {
        if (_moveDown != null)
        {
            StopCoroutine(_moveDown);
            _moveDown = null;
        }
    }

    void StartMoveUp()
    {
        if (_moveUp == null)
            _moveUp = StartCoroutine(MoveUp());
    }

    void StopMoveUp()
    {
        if (_moveUp != null)
        {
            StopCoroutine(_moveUp);
            _moveUp = null;
        }
    }
}
