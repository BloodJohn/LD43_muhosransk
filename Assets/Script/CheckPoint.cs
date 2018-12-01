using UnityEngine;
using VehicleBehaviour;

public class CheckPoint : MonoBehaviour
{
    private WheelVehicle _playerCar;
    private bool _isCheck;
    private const float _radius2Check = 2f*2f;

    void Awake()
    {
        _playerCar = FindObjectOfType<WheelVehicle>();
    }
    
    void Update()
    {
        if (_isCheck) return;

        var dist2 = (transform.position - _playerCar.transform.position).sqrMagnitude;

        if (dist2 <= _radius2Check)
        {
            Debug.Log($"Check {gameObject.name}");
            _isCheck = true;
        }
    }
}
