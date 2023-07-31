using UnityEngine;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] GameObject m_WinTitle, m_LoseTitle;


    public void ShowWin()
    {
        gameObject.SetActive(true);
        m_WinTitle.SetActive(true);
        m_LoseTitle.SetActive(false);
    }

    public void ShowLose()
    {
        gameObject.SetActive(true);
        m_WinTitle.SetActive(false);
        m_LoseTitle.SetActive(true);
    }
}
