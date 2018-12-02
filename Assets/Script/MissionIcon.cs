using UnityEngine;
using UnityEngine.UI;

public class MissionIcon : MonoBehaviour
{
    //public CheckPoint Check;
    private Camera _cameraView;
    private Image _image;

    private static readonly Vector2 _centerPos = new Vector2(0.5f, 0.5f);
    private static readonly Vector2 _leftPos = new Vector2(0, 0.5f);
    private static readonly Vector2 _rigthPos = new Vector2(1, 0.5f);
    private static readonly Vector2 _backPos = new Vector2(0.5f, 0f);

    private void Awake()
    {
        _cameraView = FindObjectOfType<Camera>();
        _image = GetComponentInChildren<Image>();
    }

    void Update()
    {
        var _mission = MissionController.Instance.CurrentMission;

        if (_mission == null)
        {
            _image.color = Color.clear;
            return;
        }

        var screenPoint = _cameraView.WorldToViewportPoint(_mission.transform.position);
        if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {
            _image.color = Color.clear;
            return;
        }

        var newPos = _backPos;
        if (screenPoint.x <= 0)
        {
            newPos = _leftPos;
        }
        else if (screenPoint.x >= 1)
        {
            newPos = _rigthPos;
        }

        _image.rectTransform.anchorMax = newPos;
        _image.rectTransform.anchorMin = newPos;
        _image.rectTransform.pivot = newPos;

        _image.color = Color.white;
    }
}
