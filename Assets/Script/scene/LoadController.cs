using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour
{
    public const string SceneName = "LoadScene";
    private string jumpInput = "Jump";

    // Update is called once per frame
    void Update()
    {
        var jumping = GetInput(jumpInput) != 0;

        if (jumping)
        {
            SceneManager.LoadScene(TutorialController.SceneName);
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
