using TallestTower.Managers;
using UnityEngine;

namespace TallestTower.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        public void PlaySinglePlayer()
        {
            GameManager.Instance.PlaySinglePlayer();
        }

        public void PlayVsAi()
        {
            GameManager.Instance.PlayVsAi();
        }

        public void Exit()
        {
            GameManager.Instance.Exit();
        }
    }
}