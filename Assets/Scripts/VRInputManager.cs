using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class VRInputManager : MonoBehaviour
{
    #region Singleton
    private static VRInputManager _instance;
    public static VRInputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VRInputManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("VRInputManager");
                    _instance = go.AddComponent<VRInputManager>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    #endregion

    private static List<InputDevice> devices = new List<InputDevice>();
    [SerializeField] InputDeviceCharacteristics inputDeviceCharacteristic = InputDeviceCharacteristics.Right;

    [System.Serializable]
    public class TriggerInputEvent : UnityEvent<bool> { }
    [SerializeField] TriggerInputEvent triggerInput;

    [System.Serializable]
    public class AxisTrackpadInputEvent : UnityEvent<Vector2> { }
    [SerializeField] AxisTrackpadInputEvent axisTrackpadInput;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnDisable()
    {
        Instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristic, devices);
        if (devices.Count > 0)
        {
            InputDevice device = devices[0];

            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisInput) && (axisInput.x != 0 || axisInput.y != 0))
            {
                axisTrackpadInput.Invoke(axisInput);
            }

            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTriggerButtonPressed) && isTriggerButtonPressed)
            {
                triggerInput.Invoke(isTriggerButtonPressed);
            }
        }

    }

}
