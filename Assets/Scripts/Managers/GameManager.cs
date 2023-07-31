using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] string m_MenuScene, m_SinglePlayerScene, m_VsAiScene;
    [SerializeField] GameConfigsData m_GameConfigs;

    List<PlayerManager> _players;

    public GameConfigsData GameConfigs => m_GameConfigs;


    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);
        else
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }
    }

    void Start()
    {
        _players = new List<PlayerManager>();
    }

    public void PlaySinglePlayer()
    {
        LoadGameSceneAsync(m_SinglePlayerScene);
    }

    public void PlayVsAi()
    {
        LoadGameSceneAsync(m_VsAiScene);
    }

    async void LoadGameSceneAsync(string scene)
    {
        Time.timeScale = 1;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }

        UpdatePlayers();
    }

    public void RestartGame()
    {
        if (SceneManager.GetActiveScene().name.Equals(m_SinglePlayerScene))
            PlaySinglePlayer();
        else
            PlayVsAi();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(m_MenuScene);
    }

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;

        foreach(PlayerManager player in _players)
        {
            player.ActiveInput(!pause);
        }
    }

    void UpdatePlayers()
    {
        _players.Clear();

        foreach (PlayerManager player in FindObjectsByType<PlayerManager>(FindObjectsSortMode.None))
        {
            _players.Add(player);
        }
    }
}
