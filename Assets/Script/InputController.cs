using UnityEngine;

public class InputController : MonoBehaviour
{
    private const float _mult = 0.01f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        var newPos = _rigidbody.transform.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
        var newRotation = transform.rotation;
        newRotation.y = _rigidbody.transform.rotation.y;
        transform.rotation = newRotation;

        if (_rigidbody.velocity.sqrMagnitude < 0.1f)
            _rigidbody.AddRelativeForce(Vector3.forward * _mult);

        if (Input.GetKey(KeyCode.LeftArrow))
            _rigidbody.AddTorque(Vector3.up * _mult, ForceMode.Force);

        if (Input.GetKey(KeyCode.RightArrow))
          _rigidbody.AddTorque(Vector3.down * _mult, ForceMode.Force);
        //_rigidbody.AddRelativeForce(Vector3.right * 0.1f);
    }
}
