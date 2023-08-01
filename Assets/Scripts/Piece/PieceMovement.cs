using TallestTower.Inputs;
using UnityEngine;

namespace TallestTower.Pieces
{
    public class PieceMovement : MonoBehaviour
    {
        [SerializeField] float m_MaxMoveDistance = 5f;

        IGameInput _gameInput;


        void Update()
        {
            if (_gameInput == null)
                return;

            Move(_gameInput.GetHorizontalDirection());

            Rotate(_gameInput.GetRotationDirection());
        }

        public void Move(int dir)
        {
            if (dir == 0)
                return;

            float pieceDist = Mathf.Abs(transform.localPosition.x);
            bool movingToBounds = transform.localPosition.x / pieceDist == dir;

            if (pieceDist >= m_MaxMoveDistance && movingToBounds)
                return;

            // the piece moves in steps of half the size of the cube, so the direction is multiplied by 0.5
            transform.Translate(dir * 0.5f * Vector3.right, Space.World);
        }

        public void Rotate(int dir)
        {
            transform.Rotate(dir * 90 * Vector3.forward);
        }

        public void SetGameInput(IGameInput gameInput)
        {
            _gameInput = gameInput;
        }
    }
}