// 7/17/2025 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;  // Assign the first camera in the Inspector
    public Camera camera2;  // Assign the second camera in the Inspector

    private void Start()
    {
        // Ensure only camera1 is active at the start
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Listen for the "C" key press
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle the active state of the cameras
            bool isCamera1Active = camera1.gameObject.activeSelf;

            camera1.gameObject.SetActive(!isCamera1Active);
            camera2.gameObject.SetActive(isCamera1Active);
        }
    }
}