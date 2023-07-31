using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EasyGameConfigsTool : EditorWindow
{
    int _winningScore = 40; 
    int _losingScore = 4;
    float _pieceFallingSpeed = 5;
    float _cameraMoveSpeed = 1;
    float _pieceMass = 10;

    GameConfigsData _gameConfigs;
    List<GameObject> _piecesPrefabs;


    [MenuItem("Tools/EasyGameConfigsTool")]
    public static void OpenWindow()
    {
        EditorWindow window = GetWindow<EasyGameConfigsTool>();
        window.titleContent = new GUIContent("Game Configs");
    }

    void Awake()
    {
        _gameConfigs = (GameConfigsData)AssetDatabase.LoadAssetAtPath("Assets/Configs/GameConfigs.asset", typeof(GameConfigsData));

        GetAllPiecesPrefab();

        _winningScore = _gameConfigs.WinningScore;
        _losingScore = _gameConfigs.LosingScore;
        _pieceFallingSpeed = _gameConfigs.PieceFallingSpeed;
        _cameraMoveSpeed = _gameConfigs.CameraMoveSpeed;
    }

    void OnGUI()
    {
        _winningScore = EditorGUILayout.IntField("Winning Score:", _winningScore);
        _losingScore = EditorGUILayout.IntField("Losing Score:", _losingScore);
        _pieceFallingSpeed = EditorGUILayout.Slider("Piece falling speed:", _pieceFallingSpeed, 1f, 15f);
        _cameraMoveSpeed = EditorGUILayout.Slider("Camera move speed:", _cameraMoveSpeed, 1f, 5f);
        _pieceMass = EditorGUILayout.Slider("Piece mass:", _pieceMass, 1f, 100f);

        if (GUILayout.Button("Save"))
        {
            _gameConfigs.WinningScore = _winningScore;
            _gameConfigs.LosingScore = _losingScore;
            _gameConfigs.PieceFallingSpeed = _pieceFallingSpeed;
            _gameConfigs.CameraMoveSpeed = _cameraMoveSpeed;

            foreach (GameObject piece in _piecesPrefabs)
            {
                if (piece != null && piece.TryGetComponent(out Rigidbody2D rigidbody))
                    rigidbody.mass = _pieceMass;
            }
        }
    }

    void GetAllPiecesPrefab() 
    {
        _piecesPrefabs = new List<GameObject>();

        string path = "/Prefabs/Pieces";
        string[] fileEntries = Directory.GetFiles(Application.dataPath + path);

        foreach (string fileName in fileEntries)
        {
            if (fileName.Contains(".meta"))
                continue;

            int index = fileName.LastIndexOf("/");
            string localPath = "Assets/Prefabs";

            if (index > 0)
                localPath += fileName.Substring(index);

            _piecesPrefabs.Add((GameObject)AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)));
        }

    }
}
