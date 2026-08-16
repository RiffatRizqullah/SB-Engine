using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
public class ControlButton : MonoBehaviour
{
    InputSystem_Actions inp;
    
    public enum ControlType
    {
        Play,
        Stop,
        Next,
        FadeIn,
        FadeOut,
        Loop
    }
    public ControlType controlType;

    ChannelEngineManager cem;
    public bool SecondaryBool;
    public Image image;
    ChannelEngine em;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inp = Manager.instance.action;
        inp.UI.RightClick.performed += RightClicked;
        
        cem = ChannelEngineManager.Instance;
        em = cem.engines[cem.selectedEngine];
    }

    void RightClicked(InputAction.CallbackContext callback)
    {
        if (callback.ReadValue<float>() == 1)
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject)
            {
                print("tes");
                SecondaryAction();
            }
        }
    }

    void SecondaryAction()
    {
        if (controlType == ControlType.FadeIn || controlType == ControlType.FadeOut)
        {
            SecondaryBool = !SecondaryBool;
            if(SecondaryBool == false)
            {
                image.DOFade(0, .5f);
            }
            else if(SecondaryBool == true)
            {
                image.DOFade(1, .5f);
            }

            if (controlType == ControlType.FadeIn)
            {
                cem.engines[0].FadeIn = SecondaryBool;
            }
            else if (controlType == ControlType.FadeOut)
            {
                cem.engines[0].FadeOut = SecondaryBool;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Click()
    {
        em = cem.engines[cem.selectedEngine];
        switch (controlType)
        {
            case ControlType.Play:
                if (em.SelectedClip != null)
                {
                    if (cem.selectedEngine == 0)
                    {
                        MusicTimeline.instance.isEnabled = true;
                    }
                    em.PlayAudio();
                }
                break;
            case ControlType.Stop:
                MusicTimeline.instance.isEnabled = false;
                em.src.Stop();
                break;
            case ControlType.Next:
                em.Next();
                break;
            case ControlType.FadeIn:
                em.Fade(em.FadeInRange.value);
                break;
            case ControlType.FadeOut:
                em.Fade(0);
                break;
            case ControlType.Loop:
                em.Toggle(em.looped);
                break;
        }
    }
}
