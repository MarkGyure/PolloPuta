using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverChangeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private Color originalColor = Color.white;
    private Color hoverColor = Color.green;

    [SerializeField]
    private string sceneToLoad = "SceneName"; // Changeable in the Inspector

    void Awake()
    {
        // Get the Image component
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("No Image component found on the GameObject.");
        }
    }

    // Called when the mouse enters the object
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = hoverColor;
        }
    }

    // Called when the mouse exits the object
    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = originalColor;
        }
    }

    // Called when the object is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked on the object!");
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name is not set in the Inspector.");
        }
    }
}
