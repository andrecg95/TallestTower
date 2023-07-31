using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PieceSpawner m_PieceSpawner;
    [SerializeField] EndMenuController m_EndMenu;
    [SerializeField] PlayerType m_PlayerType;
    [SerializeField] GameObject m_GameInput;
    [SerializeField] GameObject m_Goal;

    float _score;
    int _lostPieces;
    bool _isGameEnd;
    List<Piece> _placedPieces;

    public float Score => _score;
    public int LostPieces => _lostPieces;


    void Start()
    {
        _placedPieces = new List<Piece>();

        m_Goal.transform.position = new Vector3(m_Goal.transform.position.x, GameManager.Instance.GameConfigs.WinningScore, m_Goal.transform.position.z);

        SpawnPiece();
    }

    void UpdateScore()
    {
        if (_placedPieces.Count == 0)
            _score = 0;
        else
        {
            Piece piece = _placedPieces.OrderBy(pice => pice.transform.position.y).Last();
            _score = piece.transform.position.y + piece.GetComponent<Collider2D>().bounds.size.y / 2;
        }

        if (_score >= GameManager.Instance.GameConfigs.WinningScore)
            PlayerWin();
        else if (_lostPieces >= GameManager.Instance.GameConfigs.LosingScore)
            PlayerLose();
    }

    void SpawnPiece()
    {
        Piece newPiece = m_PieceSpawner.Spawn();
        newPiece.OnPlaced += OnPiecePlaced;

        if (newPiece.TryGetComponent(out PieceMovement piceMov))
            piceMov.SetGameInput(m_GameInput.GetComponent<IGameInput>());
    }

    void OnPiecePlaced(Piece piece)
    {
        _placedPieces.Add(piece);
        piece.OnPlaced -= OnPiecePlaced;
        piece.OnDestroyed += RemovePiece;

        UpdateScore();

        if (!_isGameEnd)
            SpawnPiece();
    }

    void RemovePiece(Piece piece)
    {
        _placedPieces.Remove(piece);
        ++_lostPieces;

        if(!_isGameEnd)
            UpdateScore();
    }

    void PlayerWin()
    {
        _isGameEnd = true;

        GameManager.Instance.PauseGame(true);

        if (m_PlayerType == PlayerType.PLAYER)
            m_EndMenu.ShowWin();
        else
            m_EndMenu.ShowLose();
    }

    void PlayerLose()
    {
        _isGameEnd = true;

        if (m_PlayerType == PlayerType.PLAYER)
        {
            GameManager.Instance.PauseGame(true);
            m_EndMenu.ShowLose();
        }
    }

    public void ActiveInput(bool active)
    {
        m_GameInput.SetActive(active);
    }
}
