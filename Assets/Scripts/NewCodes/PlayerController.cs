using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool CanInteract = false;

    [SerializeField] private int m_ghostSpeed;
    [SerializeField] private int m_playerSpeed;
    private int _currentSpeed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentSpeed = m_playerSpeed;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        _rb.velocity = movement * _currentSpeed;
    }

    public void ChangeCurrentSpeed(bool isGhost)
    {
        if (isGhost)
            _currentSpeed = m_ghostSpeed;
        else
            _currentSpeed = m_playerSpeed;
    }
    
    private void InteractWithDecor()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }

}
