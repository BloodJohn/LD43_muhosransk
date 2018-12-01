using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public static MissionUI Instance;
    public Text MessageText;

    void Awake()
    {
        Instance = this;
    }

    public void SendMessage(string message)
    {
        MessageText.text = message;
    }
}
