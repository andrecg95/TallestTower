using UnityEngine;

namespace TallestTower.Inputs
{
    public class AIInput : MonoBehaviour, IGameInput
    {
        [SerializeField] float m_PlayPeriod = 0.5f;

        int _horizontalDir;
        int _rotationDir;
        float _lastTime;


        void Start()
        {
            _lastTime = Time.time - m_PlayPeriod;
        }

        void Update()
        {
            _horizontalDir = 0;
            _rotationDir = 0;

            if (Time.time - _lastTime >= m_PlayPeriod)
            {
                _horizontalDir = Random.Range(-1, 2);
                _rotationDir = Random.Range(-1, 2);

                _lastTime = Time.time;
            }
        }

        public int GetHorizontalDirection()
        {
            return _horizontalDir;
        }

        public int GetRotationDirection()
        {
            return _rotationDir;
        }
    }
}