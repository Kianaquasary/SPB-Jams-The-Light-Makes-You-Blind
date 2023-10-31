using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject m_traps;

    public void DestroyTraps()
    {
        if (m_traps != null) Destroy(m_traps);
    }
}
