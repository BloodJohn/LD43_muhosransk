using UnityEngine;
using VehicleBehaviour;

public class CheckPoint : MonoBehaviour
{
    /*
     */


    /// <summary>Иконка персонажа</summary>
    public Sprite CharacterIcon;
    public Sprite AlertIcon;
    public Sprite FastCompleteIcon;
    public Sprite CompleteIcon;
    public Sprite FailIcon;

    /// <summary></summary>
    public string StartMessage = "New Mission";
    /// <summary></summary>
    public string FastCompleteMessage = "Complete Mission";
    /// <summary></summary>
    public string AlertMessage = "Please Help";
    /// <summary></summary>
    public string CompleteMessage = "Complete Mission";
    /// <summary></summary>
    public string FailMessage = "Mission Failed";

    private bool _isAlert;
    private bool _isFail;
    private bool _isComplete;
    private float _time;


    private const float _radius2Check = 2f*2f;
    private const float _alertDelay = 15f;
    private const float _failDelay = 45f;

    public void StartMission()
    {
        if (IsNearPoint) return;
        if (_isFail) return;

        _isComplete = false;
        _isFail = false;
        _time = 0f;
        gameObject.SetActive(true);
        MissionUI.Instance.SendMessage(StartMessage);
        MissionUI.Instance.SetCharacter(CharacterIcon);
    }

    public void UpdateMission()
    {
        if (!gameObject.activeSelf) return;
        if (_isFail) return;
        if (_isComplete) return;
        _time += Time.deltaTime;
        StatController.Instance.UpdateTime(_time);

        if (IsNearPoint)
        {
            _isComplete = true;
            gameObject.SetActive(false);

            MissionUI.Instance.SendMessage(_isAlert ? CompleteMessage : FastCompleteMessage);
            MissionUI.Instance.SetCharacter(_isAlert ? CompleteIcon : FastCompleteIcon);
            StatController.Instance.AddSuspect(_isAlert);
            return;
        }

        if (!_isAlert && _time > _alertDelay)
        {
            _isAlert = true;
            MissionUI.Instance.SendMessage(AlertMessage);
            MissionUI.Instance.SetCharacter(AlertIcon);
            return;
        }

        if (_time > _failDelay)
        {
            _isFail = true;
            gameObject.SetActive(false);
            MissionUI.Instance.SendMessage(FailMessage);
            MissionUI.Instance.SetCharacter(FailIcon);
            StatController.Instance.AddFail();
            return;
        }
    }

    private bool IsNearPoint
    {
        get
        {
            var dist2 = (transform.position - MissionController.Instance.PlayerCar.transform.position).sqrMagnitude;

            return (dist2 <= _radius2Check);
        }
    }
}
