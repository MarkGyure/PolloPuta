using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PolloHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    Vector2 heading;
    Vector2 originalPosition;
    Vector2 direction;
    Vector2 directionNormalized;

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

    public void Launch(Vector2 dir, float force)
    {
        rb.AddForce(dir * force, ForceMode2D.Impulse);

        //Debug.Log(dir * force);
    }

    public Transform transformPollo(Vector2 transform, Transform centerPosition)
    {
        transform.x /= 2;
        transform.y /= 2;

        gameObject.transform.position = new Vector2(originalPosition.x - transform.x, originalPosition.y - transform.y);

        direction = centerPosition.position - gameObject.transform.position;
        directionNormalized = direction.normalized;

        gameObject.transform.right = directionNormalized;

        return gameObject.transform;
    }
}
