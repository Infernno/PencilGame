using UnityEngine;

public class BlockObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isMoving = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        spriteRenderer.color = Utils.GetColor();

        GameManager.Instance.GameOver += Stop;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            transform.Translate(Vector2.left * Time.smoothDeltaTime * BlocksManager.Speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == R.Constants.PLAYER_TAG)
        {
            if (spriteRenderer.color == PlayerController.PencilColor)
            {
                Stop();
                animator.SetBool("isAlive", false);

                GetComponent<AudioSource>().Play();

                GameManager.Instance.OnBlockDestroyed();
            }
            else
            {
                GameManager.Instance.OnGameOver();
            }
        }
    }

    private void Stop()
    {
        isMoving = false;
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}