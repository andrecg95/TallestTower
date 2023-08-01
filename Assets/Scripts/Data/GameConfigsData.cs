using UnityEngine;

namespace TallestTower.Data
{
    [CreateAssetMenu]
    public class GameConfigsData : ScriptableObject
    {
        public int WinningScore;
        public int LosingScore;
        public float PieceFallingSpeed;
        public float CameraMoveSpeed;
    }
}