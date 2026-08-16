using UnityEngine;

public class ChannelList : MonoBehaviour
{
    public Songlist[] Sl;
    public static ChannelList instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
