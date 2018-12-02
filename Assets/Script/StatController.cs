using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public static StatController Instance;
    public Text TimeText;
    public Text SuspectText;
    public Text FailText;

    private int _suspectCount = 0;
    private int _failCount = 0;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StopTime();
        ShowStats();
    }

    public void UpdateTime(float time)
    {
        var _time = Mathf.FloorToInt(time);
        TimeText.text = _time.ToString();
    }

    private void StopTime()
    {
        TimeText.text = string.Empty;
    }

    public void AddSuspect(bool isAlert)
    {
        _suspectCount++;
        if (!isAlert) _suspectCount++;
        StopTime();
        ShowStats();
    }

    public void AddFail()
    {
        _failCount++;
        StopTime();
        ShowStats();

        if (_failCount >= 3)
        {
            SceneManager.LoadScene(FailController.SceneName);
        }
    }

    private void ShowStats()
    {
        SuspectText.text = $"Suspect {_suspectCount}";
        FailText.text = $"{_failCount} failed";
    }
}
