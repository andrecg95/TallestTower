using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] Piece[] m_PiecesPrefabs;
    [SerializeField] Transform m_PiecesContainer;
    [SerializeField] GameObject m_GameInput;
    [SerializeField] int m_SpawnWidth = 5;

    Piece _currentPiece;
    List<Piece> _placedPieces;
    public List<Piece> PlacedPieces => _placedPieces;


    void Start()
    {
        _placedPieces = new List<Piece>();

        Spawn();
    }

    void Spawn()
    {
        if (_currentPiece != null)
        {
            _currentPiece.OnPlaced -= Spawn;
            _placedPieces.Add(_currentPiece);
        }

        Piece rndPiece = m_PiecesPrefabs[Random.Range(0, m_PiecesPrefabs.Length)];
        Vector3 position = transform.position + Vector3.right * Random.Range(-m_SpawnWidth, m_SpawnWidth+1);
        Quaternion rotation = Quaternion.Euler(0, 0, 90 * Random.Range(0, 4));

        _currentPiece = Instantiate(rndPiece, position, rotation, m_PiecesContainer);
        _currentPiece.OnPlaced += Spawn;

        if (_currentPiece.TryGetComponent(out PieceMovement piceMov))
            piceMov.SetGameInput(m_GameInput.GetComponent<IGameInput>());
    }
}
