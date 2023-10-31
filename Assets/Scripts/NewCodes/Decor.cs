using UnityEngine;

public class Decor : MonoBehaviour, IInteractable
{
    [SerializeField] private float m_decorSpeed;
    [SerializeField] private float m_decorDamage;
    [SerializeField] private GameObject m_playerObject;

    public Vector3 currentVelocity;
    private Vector3 _resultSpeed;

    public void Interact()
    {

    }

    //private void DetectInteractableSide()
    //{
    //    if (Mathf.Abs(m_playerObject.transform.position.x - transform.position.x )> Mathf.Abs(m_playerObject.transform.position.z - transform.position.z))
    //    {
    //        _resultSpeed = new Vector3(Mathf.Sign(transform.position.x - m_playerObject.transform.position.x) * m_decorSpeed, 0, 0);
    //    }
    //    else
    //    {
    //        _resultSpeed = new Vector3(0, 0, Mathf.Sign(transform.position.z - m_playerObject.transform.position.z) * m_decorSpeed);
    //    }
    //}

}
