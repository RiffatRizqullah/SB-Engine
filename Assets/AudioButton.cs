using UnityEngine;
using UnityEngine.EventSystems;
public class AudioButton : MonoBehaviour
{
    public int channel;
    public AudioClip Clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Clicked()
    {
        ChannelEngineManager.Instance.engines[channel].SelectAudio(ChannelList.instance.Sl[channel].clips[int.Parse(gameObject.name)],transform);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void ClickedSFX()
    {
        ChannelEngineManager.Instance.engines[channel].SelectAudio(ChannelList.instance.Sl[channel].clips[int.Parse(gameObject.name)], transform);
        EventSystem.current.SetSelectedGameObject(gameObject);
        ChannelEngineManager.Instance.engines[channel].PlayAudioSFX();
    }
    public void ClickedAmb()
    {
        ChannelEngineManager.Instance.engines[channel].SelectAudio(ChannelList.instance.Sl[channel].clips[int.Parse(gameObject.name)], transform);
        EventSystem.current.SetSelectedGameObject(gameObject);
        ChannelEngineManager.Instance.engines[channel].PlayAudio();
    }
}
