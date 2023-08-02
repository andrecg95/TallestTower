using UnityEngine;

namespace TallestTower.Controllers
{
    public class EndMenuController : MonoBehaviour
    {
        [SerializeField] GameObject m_Win, m_Lose;
        [SerializeField] AudioSource m_GameMusic;


        public void ShowWin()
        {
            gameObject.SetActive(true);
            m_Win.SetActive(true);
            m_Lose.SetActive(false);

            m_Win.GetComponent<AudioSource>().Play();
            m_GameMusic.Stop();
        }

        public void ShowLose()
        {
            gameObject.SetActive(true);
            m_Win.SetActive(false);
            m_Lose.SetActive(true);

            m_Lose.GetComponent<AudioSource>().Play();
            m_GameMusic.Stop();
        }
    }
}