using UnityEngine;

public class Revive : MonoBehaviour
{
    [SerializeField] private PlayerGhost m_playerGhost;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            m_playerGhost.ChangeToLiving();
            Destroy(other.gameObject);
        }
            
    }
}
