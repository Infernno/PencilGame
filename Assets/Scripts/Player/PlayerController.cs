using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Color PencilColor { get; private set; }
    public Sprite[] Sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SwitchSprite(0);
    }

    public void SwitchSprite(int color)
    {
        spriteRenderer.sprite = Sprites[color];

        switch (color)
        {
            case 0:
                PencilColor = Color.red;
                break;
            case 1:
                PencilColor = Color.green;
                break;
            case 2:
                PencilColor = Color.blue;
                break;
            case 3:
                PencilColor = Color.yellow;
                break;
            default:
                PencilColor = Color.red;
                break;
        }
    }
}