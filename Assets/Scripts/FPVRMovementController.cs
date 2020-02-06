using UnityEngine;

public class FPVRMovementController : MonoBehaviour
{

    private Vector3 _velocity = Vector3.zero;
    [SerializeField] float _characterSpeed = 10f;
    CharacterController _characterController;

    private void Awake()
    {
        _characterController = gameObject.AddComponent<CharacterController>();
    }

    public void OnVRTriggerPressed(bool isTriggerPressed)
    {
        if (isTriggerPressed)
        {
            //todo implement something later
        }
        else
        {
            //todo implement something later
        }

    }

    public void OnVRTrackpadInput(Vector2 axisInput)
    {
        if (axisInput.y > 0f)
        {
            Vector3 direction = Camera.main.transform.forward;
            _velocity = _characterSpeed * direction.normalized;
        }
        else if (axisInput.y < 0f)
        {
            Vector3 direction = -Camera.main.transform.forward;
            _velocity = _characterSpeed * direction.normalized;
        }
        else
        {
            _velocity = Vector3.zero;
        }
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
