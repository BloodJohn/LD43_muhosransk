using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public const string SceneName = "TutorialScene";
    private string jumpInput = "Jump";

    // Update is called once per frame
    void Update()
    {
        var jumping = GetInput(jumpInput) != 0;

        if (jumping)
        {
            SceneManager.LoadScene(MissionController.SceneName);
        }
    }

    private float GetInput(string input)
    {
#if MULTIOSCONTROLS
        return MultiOSControls.GetValue(input, playerId);
#else
        return Input.GetAxis(input);
#endif
    }
}
