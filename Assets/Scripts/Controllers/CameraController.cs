using TallestTower.Managers;
using UnityEngine;

namespace TallestTower.Controllers
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] PlayerManager m_PlayerManager;
        [SerializeField] float m_OffsetY;

        float _initPosY;


        void Start()
        {
            _initPosY = transform.position.y;
        }

        void Update()
        {
            float destPoint = Mathf.Max(_initPosY, m_PlayerManager.Score + m_OffsetY);
            float distance = destPoint - transform.position.y;

            transform.Translate(distance * Time.deltaTime * GameManager.Instance.GameConfigs.CameraMoveSpeed * Vector3.up);
        }
    }
}