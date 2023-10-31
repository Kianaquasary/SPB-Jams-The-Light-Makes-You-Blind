using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    public bool IsGhost = false;

    [SerializeField] private Material m_ghostMaterial;
    [SerializeField] private Material m_playerMaterial;
    [SerializeField] private GameObject m_bodyPrefab;

    private MeshRenderer _playerRenderer;
    private CapsuleCollider _capsuleCollider;
    private PlayerController _playerController;

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _playerRenderer = GetComponent<MeshRenderer>();
        _playerController = GetComponent<PlayerController>();
    }

    public void ChangeToGhost()
    {
        IsGhost = !IsGhost;
        Instantiate(m_bodyPrefab, this.transform.position, Quaternion.identity);
        _playerController.ChangeCurrentSpeed(IsGhost);
        _capsuleCollider.isTrigger = true;
        _playerRenderer.material = m_ghostMaterial;
    }

    public void ChangeToLiving()
    {
        IsGhost = !IsGhost;
        _playerController.ChangeCurrentSpeed(IsGhost);
        _capsuleCollider.isTrigger = false;
        _playerRenderer.material = m_playerMaterial;
    }
}
