using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] Piece[] m_PiecesPrefabs;
    [SerializeField] Transform m_PiecesContainer;
    [SerializeField] float m_SpawnWidth = 1;

    Transform _transform;
    Piece _currentPiece;


    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (_currentPiece != null)
            _currentPiece.OnPlaced -= Spawn;

        Piece rndPiece = m_PiecesPrefabs[Random.Range(0, m_PiecesPrefabs.Length)];
        Vector3 position = _transform.position + Vector3.right * Random.Range(-m_SpawnWidth/2, m_SpawnWidth/2);
        Quaternion rotation = Quaternion.Euler(0, 0, 90 * Random.Range(0, 4));

        _currentPiece = Instantiate(rndPiece, position, rotation, m_PiecesContainer);
        _currentPiece.OnPlaced += Spawn;
    }
}
