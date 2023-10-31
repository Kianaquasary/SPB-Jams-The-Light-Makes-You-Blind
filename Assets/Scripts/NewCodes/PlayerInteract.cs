using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactableObject;
    private bool isInteracted;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactableObject != null)
        {
            InteractWithObject(interactableObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Decor>())
            interactableObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Decor>())
            interactableObject = null;
    }

    //Works only with one interactable item
    private void InteractWithObject(GameObject interactableObject)
    {
        if (isInteracted == false)
        {
            Destroy(interactableObject.GetComponent<Rigidbody>());
            interactableObject.transform.SetParent(gameObject.transform);
            isInteracted = true;
        }
        else
        {
            interactableObject.transform.SetParent(null);
            interactableObject.AddComponent<Rigidbody>();
            isInteracted = false;
        }
    }
}
