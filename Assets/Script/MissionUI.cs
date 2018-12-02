using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public static MissionUI Instance;
    public Text MessageText;
    public Image CharacterIcon;

    void Awake()
    {
        Instance = this;
        CharacterIcon.gameObject.SetActive(false);
    }

    public void SendMessage(string message)
    {
        MessageText.text = message;
    }

    public void SetCharacter(Sprite sprite)
    {
        if (sprite != null)
        {
            CharacterIcon.sprite = sprite;
            CharacterIcon.gameObject.SetActive(true);
        }
        else
        {
            CharacterIcon.gameObject.SetActive(false);
        }
    }
}
