using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _positionOffSet;
    
    private Vector3 _lastTargetPosition;

    private Vector3 TargetPosition => _target.position;

    private void Update()
    {
        if(TargetPosition != _lastTargetPosition)
            Follow();
    }

    private void Follow()
    {
        transform.position = TargetPosition + _positionOffSet;
        _lastTargetPosition = TargetPosition;
    }
}
