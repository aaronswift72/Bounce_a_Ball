using UnityEngine;

public class SnailMovementSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite left;
    public Sprite right;

    public float deadZone = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0f;

        if (velocity.magnitude < deadZone)
            return;

        // Decide based on strongest axis
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
        {
            spriteRenderer.sprite = velocity.x > 0 ? right : left;
        }
        else
        {
            // Forward/backward reuse left/right
            spriteRenderer.sprite = velocity.z > 0 ? right : left;
        }
    }
}