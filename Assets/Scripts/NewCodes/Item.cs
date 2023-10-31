using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPickable
{
    public Sprite ItemIcon;
    [SerializeField] private PlayerInventory m_inventory;
    private bool _isPickable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInventory>())
            _isPickable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInventory>())
            _isPickable = false;
    }

    public void PickItem()
    {
        if (_isPickable)
        {
            m_inventory.Items.Add(this);
            Destroy(gameObject);
        }
    }
}
