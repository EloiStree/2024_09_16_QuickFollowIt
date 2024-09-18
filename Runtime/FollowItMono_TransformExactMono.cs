using UnityEngine;

public class FollowItMono_TransformExactMono : MonoBehaviour
{
    public Transform m_target;
    public Transform m_whatToMove;

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
            m_whatToMove.position = m_target.position;
            m_whatToMove.rotation = m_target.rotation;
        }
    }
}
