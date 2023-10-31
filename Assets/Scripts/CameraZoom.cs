using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{


    public CinemachineFreeLook freeLookCam;
    public float zoomSpeed = 1.0f;
    public float minFieldOfView = 20f;
    public float maxFieldOfView = 60f;

    private void Update()
    {
        // Get the mouse scroll input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the new field of view
        float newFieldOfView = freeLookCam.m_Lens.FieldOfView - scrollInput * zoomSpeed;

        // Clamp the field of view to the specified min and max values
        newFieldOfView = Mathf.Clamp(newFieldOfView, minFieldOfView, maxFieldOfView);

        // Update the Cinemachine FreeLook component's field of view
        freeLookCam.m_Lens.FieldOfView = newFieldOfView;
    }
}
