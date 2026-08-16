using TMPro;

using UnityEngine;
using UnityEngine.UI;
public class MusicTimeline : MonoBehaviour
{
    public static MusicTimeline instance {  get; private set; }

    public int channelID;
    public bool isEnabled;
    public float length;
    public float duration;
    float remaining;

    public TextMeshProUGUI[] texts;

    public float[] minutes;
    public float[] seconds;

    [SerializeField]Slider slider;

    public bool setSlider;

    AudioSource src;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            Refresh();
            remaining = length - duration;
            Apply();
        }


    }

    void Apply()
    {
        //Calculate
        minutes[0] = Mathf.Round(duration / 60);
        seconds[0] = Mathf.Round(duration % 60);
        minutes[1] = Mathf.Round(length / 60);
        seconds[1] = Mathf.Round(length % 60);
        minutes[2] = Mathf.Round(remaining / 60);
        seconds[2] = Mathf.Round(remaining % 60);

        texts[0].text = $"{(int)minutes[0]:D2}:{(int)seconds[0]:D2}";
        texts[1].text = $"{(int)minutes[1]:D2}:{(int)seconds[1]:D2}";
        texts[2].text = $"-{(int)minutes[2]:D2}:{(int)seconds[2]:D2}";

        if (setSlider == true)
        {
            slider.value = (float)duration / length;
        }
        else if(setSlider == false)
        {
            duration = slider.value * length;

        }
    }
    void Refresh()
    {
        src = ChannelEngineManager.Instance.engines[channelID].GetComponent<AudioSource>();
        length = src.clip.length;
        duration = src.time;
       

    }

    public void SetSlider(int type)
    {
        print("Debug1");
        if (type == 0)
        {
            setSlider = false;
        }
        else if (type == 1)
        {
            setSlider = true;
            src.time = duration;
        }
    }
}
