using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ChannelEngineManager : MonoBehaviour
{
    public static ChannelEngineManager Instance;
    public ChannelEngine[] engines;

    public int selectedEngine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeEngine(Slider slider)
    {
        selectedEngine = (int)slider.value;
    }
}
