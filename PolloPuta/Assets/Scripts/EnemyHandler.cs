using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    // The velocity threshold at which the object will be destroyed
    public float destructionVelocityThreshold = 3f;

    // Reference to the Rigidbody2D component (used to detect velocity)
    private Rigidbody2D rb2d;

    // Reference to the particle system prefab to be instantiated upon destruction
    public GameObject explosionFX;

    // Reference to the position where the particle effect should be played (optional)
    private Vector3 destructionEffectPosition;

    [SerializeField] private LevelController levelController;

    void Start()
    {
        // Get the Rigidbody2D component if it's not already assigned
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the velocity at the point of collision
        float collisionVelocity = rb2d.velocity.magnitude;

        // Debug log for velocity
        //Debug.Log($"Collision velocity: {collisionVelocity}");

        // If the collision velocity is higher than the threshold, destroy the object
        if (collisionVelocity > destructionVelocityThreshold)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        // Get the current position of the object (this is where the particle effect will spawn)
        destructionEffectPosition = transform.position;

        // Play the particle effect if it is assigned
        if (explosionFX != null)
        {
            GameObject effect = Instantiate(explosionFX, destructionEffectPosition, Quaternion.identity);

            // Destroy the particle effect after 0.75 seconds
            Destroy(effect.gameObject, 0.5f);
        }
        else
        {
            //Debug.Log("No particle effect set for this object.");
        }

        // Optionally: You can also add sound effects, camera shake, etc.
        //Debug.Log($"{gameObject.name} destroyed due to high velocity impact!");

        // Destroy the object after particles are instantiated (optional delay)
        Destroy(gameObject);

        levelController.OnEnemyKilled();
    }
}
