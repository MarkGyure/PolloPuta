using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PolloHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    Vector2 heading;
    Vector2 originalPosition;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        rb.simulated = false;
        circleCollider.enabled = false;

        originalPosition = rb.position;
    }

    public Vector2 updatePosition(Vector3 worldPosition)
    {
        heading.x = (worldPosition.x - originalPosition.x) * -1;
        heading.y = (worldPosition.y - originalPosition.y) * -1;

        return heading;
    }

    public void polloReleased()
    {
        rb.simulated = true;
        circleCollider.enabled = true;
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public Transform transformPollo(Vector2 transform)
    {
        transform.x /= 2;
        transform.y /= 2;

        gameObject.transform.position = new Vector2(originalPosition.x - transform.x, originalPosition.y - transform.y);

        return gameObject.transform;
    }
}
