using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] string m_MenuScene, m_GameScene;


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

    void Update()
    {
        
    }

    public void PlaySinglePlayer()
    {
        SceneManager.LoadScene(m_GameScene);
    }

    public void PlayVsAi()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(m_GameScene);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(m_MenuScene);
        Time.timeScale = 1;
    }

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;

        PlayerInput playerInput = FindObjectOfType<PlayerInput>(true);

        if (playerInput != null)
            playerInput.enabled = !pause;
    }
}
