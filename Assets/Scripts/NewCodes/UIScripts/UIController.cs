using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerInteract m_playerInteract;
    [SerializeField] private PlayerInventory m_playerInventory;
    [SerializeField] private Image m_KeyImage;

    [SerializeField] private Button m_inventoryButton;
    [SerializeField] private GameObject m_inventoryContainer;

    private void Update()
    {
        SetInteractableButtonText();
    }

    private void OnEnable()
    {
        PlayerInventory.onItemPickup += AddItem;
    }

    private void OnDisable()
    {
        PlayerInventory.onItemPickup -= AddItem;
    }

    private void SetInteractableButtonText()
    {
        if (m_playerInteract.interactableObject != null && m_playerInventory.pickableObject == null)
        {
            m_inventoryButton.GetComponentInChildren<TMP_Text>().text = "F";
            m_inventoryButton.gameObject.SetActive(true);
        }
        else if (m_playerInventory.pickableObject != null && m_playerInteract.interactableObject == null)
        {
            m_inventoryButton.GetComponentInChildren<TMP_Text>().text = "E";
            m_inventoryButton.gameObject.SetActive(true);
        }
        else
        {
            m_inventoryButton.GetComponentInChildren<TMP_Text>().text = "";
            m_inventoryButton.gameObject.SetActive(false);
        }
    }

    private void AddItem()
    {
        if (m_playerInventory.pickableObject != null)
            Instantiate(m_KeyImage, m_inventoryContainer.transform);
    }
}
