using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPanelManager : MonoBehaviour
{
    public static ControlPanelManager instance { get; private set; }
    InputAction PlayMusic;
    InputAction NextMusic;
    InputAction StopMusic;
    InputAction FadeIn;
    InputAction FadeOut;
    InputAction ToggleLoop;
    CanvasGroup cg;

    public ControlButton[] btns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cg = GetComponent<CanvasGroup>();
        PlayMusic = Manager.instance.action.UI.PlayMusic;
        NextMusic = Manager.instance.action.UI.NextMusic;
        StopMusic = Manager.instance.action.UI.StopMusic;
        FadeIn = Manager.instance.action.UI.FadeIn;
        FadeOut = Manager.instance.action.UI.FadeOut;
        ToggleLoop = Manager.instance.action.UI.ToggleLoop;

        PlayMusic.performed += (a =>
        {
            print("1");
            btns[0].Click();
        });
        NextMusic.performed += (b =>
        {
            print("2");
            btns[2].Click();
        });
        StopMusic.performed += (c =>
        {
            print("3");
            btns[1].Click();
        });
        ToggleLoop.performed += (x =>
        {
            btns[3].Click();
        });
        FadeIn.performed += (y =>
        {
            btns[4].Click();
        });
        FadeOut.performed += (z =>
        {
            btns[5].Click();
        });


    }

    public void SetInteractable()
    {
        cg.interactable = !cg.interactable;
    }
    public void SetInteractable(bool interactable)
    {
        cg.interactable = interactable;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
