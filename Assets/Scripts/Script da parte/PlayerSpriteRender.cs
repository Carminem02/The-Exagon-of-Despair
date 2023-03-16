using UnityEngine;

public class PlayerSpriteRender : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement2 movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprites run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement2>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = movement.running;

        if (movement.jumping)
        {
            spriteRenderer.sprite = jump;
        }
        else if (movement.sliding)
        {
            spriteRenderer.sprite = slide;
        }
        else if (!movement.running)
        {
            spriteRenderer.sprite = idle;
        }
    }
}
