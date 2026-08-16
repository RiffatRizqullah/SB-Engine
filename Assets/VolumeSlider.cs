using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] int channelID;
    Slider slider;
    public bool set;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetEnable()
    {
        slider.interactable = !slider.interactable;
        callback();
    }

    public void SetEnable(bool enable)
    {
        slider.interactable = enable;
        callback();
    }

    void callback()
    {
        set = slider.interactable;
    }
    // Update is called once per frame
    void Update()
    {
        if(set == false)
        {
            slider.value = ChannelEngineManager.Instance.engines[channelID].src.volume;
        }
    }
    public void SetVolume()
    {
        ChannelEngineManager.Instance.engines[channelID].src.volume = slider.value;
    }
}
