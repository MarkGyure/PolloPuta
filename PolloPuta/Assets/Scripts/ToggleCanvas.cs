using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvas; // Assign your Canvas in the Inspector

    void Start()
    {
        if (canvas == null)
        {
            Debug.LogError("Canvas is not assigned in the Inspector.");
            return;
        }

        // Ensure the Canvas is initially disabled
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the Canvas active state
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }
}