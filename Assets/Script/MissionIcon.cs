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
        var onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen)
        {
            _image.rectTransform.anchorMax = _centerPos;
            _image.rectTransform.anchorMin = _centerPos;
            _image.rectTransform.pivot = _centerPos;
            _image.color = Color.clear;
        }
        else
        {
            _image.color = Color.white;
            if (screenPoint.x <= 0)
            {

                _image.rectTransform.anchorMax = _leftPos;
                _image.rectTransform.anchorMin = _leftPos;
                _image.rectTransform.pivot = _leftPos;
            }
            if (screenPoint.x >= 1)
            {
                _image.rectTransform.anchorMax = _rigthPos;
                _image.rectTransform.anchorMin = _rigthPos;
                _image.rectTransform.pivot = _rigthPos;
            }
        }
    }
}
