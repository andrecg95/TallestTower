using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] PieceSpawner m_PieceSpawner;
    [SerializeField] float m_UpdateScorePeriod = 1;

    float _score;
    public float Score => _score;


    void Start()
    {
        InvokeRepeating("UpdateScore", 1, m_UpdateScorePeriod);
    }

    void UpdateScore()
    {
        if (m_PieceSpawner.PlacedPieces.Count == 0)
        {
            _score = 0;
            return;
        }

        Piece piece = m_PieceSpawner.PlacedPieces.OrderBy(pice => pice.transform.position.y).Last();
        _score = piece.transform.position.y + piece.GetComponent<Collider2D>().bounds.size.y / 2;
    }

}
