using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleAnimator : MonoBehaviour
{
    public Animator animator;  
    private Image image;
  

    void Awake()
    {
        // Get the Image component attached to the same GameObject
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("No Image component found! Attach this script to a GameObject with a UI Image.");
        }

        if (animator == null)
        {
            Debug.LogError("No Animator assigned! Drag the Animator component into the script's inspector.");
        }
    }

    void Start()
    {
        StartCoroutine(HandleUIAnimation());
    }

    private IEnumerator HandleUIAnimation()
    {
        
            // Disable the image at the start
            image.enabled = false;

            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);

            // Enable the image
            image.enabled = true;

            // Play the animation
            if (animator != null)
            {
            animator.SetBool("PlayAnimation", true);
        }
    }
    public void CancelAnimation()
    {

        animator.enabled = false;
    }
}
