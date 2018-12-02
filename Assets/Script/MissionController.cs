using System;
using System.Linq;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public static MissionController Instance;
    private CheckPoint[] _missionList;

    void Awake()
    {
        Instance = this;
        _missionList = FindObjectsOfType<CheckPoint>();
    }

    private void Update()
    {
        foreach (var checkPoint in _missionList)
        {
            checkPoint.CheckComplete();
        }
    }

    public CheckPoint CurrentMission => _missionList.FirstOrDefault(item => !item.IsComplete);
}
