using UnityEngine;
using VehicleBehaviour;

public class CheckPoint : MonoBehaviour
{
    public string StartMission = "New Mission";
    public string CompleteMission = "Complete Mission";

    private WheelVehicle _playerCar;
    public bool IsComplete;
    private const float _radius2Check = 2f*2f;

    void Awake()
    {
        _playerCar = FindObjectOfType<WheelVehicle>();
    }

    private void Start()
    {
        MissionUI.Instance.SendMessage(StartMission);
    }

    public void CheckComplete()
    {
        if (IsComplete) return;

        var dist2 = (transform.position - _playerCar.transform.position).sqrMagnitude;

        if (dist2 <= _radius2Check)
        {
            MissionUI.Instance.SendMessage(CompleteMission);
            IsComplete = true;
            gameObject.SetActive(false);
        }
    }
}
