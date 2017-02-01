using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class SpriteChange : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;

    public bool SaveState;
    public string StateSource;

    private Image image;
    private Button button;

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (image != null && button != null)
        {
            image.sprite = On;

            if (SaveState)
            {
                var content = StateSource.Split('.');

                var className = System.Type.GetType(content[0]);
                var property = className.GetProperty(content[1]);

                bool value = (bool) property.GetValue(null, null);

                image.sprite = value ? On : Off;
            }

            button.onClick.AddListener(() =>
            {
                image.sprite = image.sprite == On ? Off : On;
            });
        }
    }
}