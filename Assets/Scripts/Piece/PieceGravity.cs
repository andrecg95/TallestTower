using TallestTower.Managers;
using UnityEngine;

namespace TallestTower.Pieces
{
    public class PieceGravity : MonoBehaviour
    {

        void Update()
        {
            transform.position += GameManager.Instance.GameConfigs.PieceFallingSpeed * Time.deltaTime * Vector3.down;
        }
    }
}