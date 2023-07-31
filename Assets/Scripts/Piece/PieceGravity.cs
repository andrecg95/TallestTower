using UnityEngine;

public class PieceGravity : MonoBehaviour
{

    void Update()
    {
        transform.position += GameManager.Instance.GameConfigs.PieceFallingSpeed * Time.deltaTime * Vector3.down;
    }
}
