using UnityEngine;

public class FollowItMono_TransformLerpMono : MonoBehaviour
{
    public Transform m_target;
    public Transform m_whatToMove;
    public float m_lerpSpeedMove = 0.2f;
    public float m_lerpSpeedRotate = 0.65f;

    public bool m_useLateUpdate;
    void Update()
    {
        if (!m_useLateUpdate)
            UpdateLerp();
    }
    void LateUpdate()
    {
        if (m_useLateUpdate)
            UpdateLerp();
    }

    private void UpdateLerp()
    {
        if (m_target != null && m_whatToMove != null)
        {
            float moveStep = m_lerpSpeedMove * Time.deltaTime;
            float rotateStep = m_lerpSpeedRotate * Time.deltaTime;

            // Ensure we reach the target instead of getting stuck approaching infinitely
            m_whatToMove.position = Vector3.MoveTowards(m_whatToMove.position, m_target.position, moveStep);
            m_whatToMove.rotation = Quaternion.RotateTowards(m_whatToMove.rotation, m_target.rotation, rotateStep);
        }
    }


    [ContextMenu("Move to exact position")]
    public void MoveToExactPosition() { 
    
        if (m_target != null && m_whatToMove != null)
        {
            m_whatToMove.position = m_target.position;
            m_whatToMove.rotation = m_target.rotation;
        }
    }
}
