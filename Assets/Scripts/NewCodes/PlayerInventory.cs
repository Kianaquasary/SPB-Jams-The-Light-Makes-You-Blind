using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [System.NonSerialized] public List<Item> Items = new List<Item>();
    public static Action onItemPickup;
    public GameObject pickableObject;

    public KeyCode activationKey = KeyCode.Tab;
    public GameObject objectToActivate;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickableObject != null)
        {
            PickupItem(pickableObject);
            onItemPickup?.Invoke();
        }

        if (Input.GetKeyDown(activationKey))
        {
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
            pickableObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Item>())
            pickableObject = null;
    }

    //Works only with one interactable item
    private void PickupItem(GameObject gameObject)
        => gameObject.GetComponent<Item>().PickItem();
}
