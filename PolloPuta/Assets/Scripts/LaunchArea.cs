using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchArea : MonoBehaviour
{
    [SerializeField] private LayerMask launchAreaMask;

    public bool IsWithinArea()
    {
        Vector2 worldPositon = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if(Physics2D.OverlapPoint(worldPositon))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
