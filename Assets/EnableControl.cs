using UnityEngine;

public class EnableControl : MonoBehaviour
{
    public CanvasGroup[] cg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void SetInteractable()
    {
        foreach(CanvasGroup canvas in cg)
        {
            canvas.interactable = !canvas.interactable;
        }
    }

    public void SetInteractable(bool set)
    {
        foreach (CanvasGroup canvas in cg)
        {
            canvas.interactable = set;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
