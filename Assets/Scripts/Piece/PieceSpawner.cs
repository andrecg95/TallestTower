using System;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] Piece[] m_PiecesPrefabs;
    [SerializeField] Transform m_PiecesContainer;
    [SerializeField] int m_SpawnWidth = 5;


    public Piece Spawn()
    {
        Piece rndPiece = m_PiecesPrefabs[UnityEngine.Random.Range(0, m_PiecesPrefabs.Length)];
        Vector3 position = transform.position + Vector3.right * UnityEngine.Random.Range(-m_SpawnWidth, m_SpawnWidth+1);
        Quaternion rotation = Quaternion.Euler(0, 0, 90 * UnityEngine.Random.Range(0, 4));

        Piece newPiece = Instantiate(rndPiece, position, rotation, m_PiecesContainer);

        return newPiece;
    }
}
