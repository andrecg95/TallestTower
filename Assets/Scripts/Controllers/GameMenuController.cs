using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public void Pause()
    {
        GameManager.Instance.PauseGame(true);

        gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.Instance.PauseGame(false);

        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();

        gameObject.SetActive(false);
    }

    public void ExitToMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
