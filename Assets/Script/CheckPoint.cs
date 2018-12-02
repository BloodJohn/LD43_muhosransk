using UnityEngine;
using VehicleBehaviour;

public class CheckPoint : MonoBehaviour
{
    public string StartMessage = "New Mission";
    public string AlertMessage = "Please Help";
    public string CompleteMessage = "Complete Mission";
    public string FailMessage = "Mission Failed";

    private WheelVehicle _playerCar;
    private bool _isAlert;
    private bool _isFail;
    private bool _isComplete;
    private float _time;


    private const float _radius2Check = 2f*2f;
    private const float _alertDelay = 5f;
    private const float _failDelay = 15f;

    void Awake()
    {
        _playerCar = FindObjectOfType<WheelVehicle>();
    }

    public void StartMission()
    {
        if (IsNearPoint) return;
        if (_isFail) return;

        _isComplete = false;
        _isFail = false;
        _time = 0f;
        gameObject.SetActive(true);
        MissionUI.Instance.SendMessage(StartMessage);
    }

    public void CheckComplete()
    {
        if (!gameObject.activeSelf) return;
        if (_isFail) return;
        if (_isComplete) return;
        _time += Time.deltaTime;

        if (IsNearPoint)
        {
            _isComplete = true;
            gameObject.SetActive(false);
            MissionUI.Instance.SendMessage(CompleteMessage);
            return;
        }

        if (!_isAlert && _time > _alertDelay)
        {
            _isAlert = true;
            MissionUI.Instance.SendMessage(AlertMessage);
            return;
        }

        if (_time > _failDelay)
        {
            _isFail = true;
            gameObject.SetActive(false);
            MissionUI.Instance.SendMessage(FailMessage);
            return;
        }
    }

    private bool IsNearPoint
    {
        get
        {
            var dist2 = (transform.position - _playerCar.transform.position).sqrMagnitude;

            return (dist2 <= _radius2Check);
        }
    }
}
