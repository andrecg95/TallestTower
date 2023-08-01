using UnityEngine;

namespace TallestTower.Inputs
{
    public class PlayerInput : MonoBehaviour, IGameInput
    {
        Vector2 _touchStartPosition;
        bool _isDrag;
        int _dragThreshold;

        int _horizontalDir;
        int _rotationDir;

        // The start calulates the threshold used to move the pieces based on the pixels occupied by a block
        void Start()
        {
            Camera camera = Camera.main;

            var blockStart = camera.WorldToScreenPoint(Vector3.zero);
            var blockEnd = camera.WorldToScreenPoint(Vector3.right);

            _dragThreshold = (int)Mathf.Abs(blockEnd.x - blockStart.x);
        }

        void Update()
        {
            _horizontalDir = 0;
            _rotationDir = 0;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _touchStartPosition = touch.position;
                        _isDrag = false;
                        break;

                    case TouchPhase.Moved:
                        if (_isDrag)
                            Drag(touch.position);
                        else
                            _isDrag = Mathf.Abs(touch.position.x - _touchStartPosition.x) > _dragThreshold;
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        if (!_isDrag)
                            Tap();
                        break;
                }
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

        void Tap()
        {
            _rotationDir = 1;
        }

        void Drag(Vector2 touchPosition)
        {
            if (Mathf.Abs(touchPosition.x - _touchStartPosition.x) > _dragThreshold)
            {
                _horizontalDir = touchPosition.x > _touchStartPosition.x ? 1 : -1;
                _touchStartPosition = touchPosition;
            }
        }
    }
}