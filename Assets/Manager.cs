using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }
    public InputSystem_Actions action;
    InputAction SetChannel;
    InputAction SetChannel1;
    InputAction SetChannel2;
    InputAction SetChannel3;
    public Slider sliderengines;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        action = new InputSystem_Actions();
        action.Enable();

        SetChannel = Manager.instance.action.UI.SetChannel;
        SetChannel1 = Manager.instance.action.UI.SetChannel1;
        SetChannel2 = Manager.instance.action.UI.SetChannel2;
        SetChannel3 = Manager.instance.action.UI.SetChannel3;
        SetChannel.performed += (v =>
        {
            sliderengines.value = 0;
        });

        SetChannel1.performed += (v =>
        {
            sliderengines.value = 1;
        });

        SetChannel2.performed += (v =>
        {
            sliderengines.value = 2;
        });

        SetChannel3.performed += (v =>
        {
            sliderengines.value = 3;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
