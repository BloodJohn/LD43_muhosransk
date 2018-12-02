using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissionController : MonoBehaviour
{
    public static MissionController Instance;
    private CheckPoint[] _missionList;
    private float _startCountDown;

    public CheckPoint CurrentMission => _missionList.FirstOrDefault(item => item.gameObject.activeSelf);

    void Awake()
    {
        Instance = this;
        _missionList = FindObjectsOfType<CheckPoint>();

        foreach (var checkPoint in _missionList)
        {
            checkPoint.gameObject.SetActive(false);
        }

        Random.InitState(DateTime.Now.Millisecond);
    }

    private void Update()
    {
        if (CurrentMission == null)
        {
            _startCountDown -= Time.deltaTime;

            if (_startCountDown < 0f)
            {
                var index = Random.Range(0, _missionList.Length);
                _missionList[index].StartMission();
                _startCountDown = 5f;
            }
        }

        foreach (var checkPoint in _missionList)
            checkPoint.UpdateMission();
    }


}
