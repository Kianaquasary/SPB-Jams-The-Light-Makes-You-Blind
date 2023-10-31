using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilitySwitch : MonoBehaviour
{
    public SkinnedMeshRenderer[] renderers; // Array of SkinnedMeshRenderer components

    private bool isVisible = true; // Flag to track visibility state

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        isVisible = !isVisible; // Invert visibility state

        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            renderer.enabled = isVisible;
        }
    }
}
