using UnityEngine;

public class SnailMovementSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite left;
    public Sprite right;

    public float deadZone = 0.1f;

    private Rigidbody rb;
    private int lastDirection = 1; // 1 = right, -1 = left

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Horizontal billboard 
        if (Camera.main != null)
        {
            Vector3 flatForward = Camera.main.transform.forward;
            flatForward.y = 0f;

            if (flatForward.sqrMagnitude > 0.001f)
            {
                flatForward.Normalize();
                transform.forward = flatForward;
            }
        }

        // Camera-relative movement direction
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0f;

        if (velocity.magnitude > deadZone && Camera.main != null)
        {
            Vector3 moveDir = velocity.normalized;

            // Camera's horizontal right vector
            Vector3 camRight = Camera.main.transform.right;
            camRight.y = 0f;
            camRight.Normalize();

            float dot = Vector3.Dot(moveDir, camRight);

            lastDirection = dot >= 0f ? 1 : -1;
        }

        spriteRenderer.sprite = lastDirection == 1 ? right : left;
    }
}