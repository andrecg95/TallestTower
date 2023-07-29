using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] ScoreManager m_ScoreManager;
    [SerializeField] float m_OffsetY;
    [SerializeField] float m_MoveSpeed = 1f; 

    float _initPosY;


    void Start()
    {
        _initPosY = transform.position.y;
    }

    void Update()
    {
        float destPoint = Mathf.Max(_initPosY, m_ScoreManager.Score + m_OffsetY);
        float distance = destPoint - transform.position.y;

        transform.Translate(distance * Time.deltaTime * m_MoveSpeed * Vector3.up);
    }
}
