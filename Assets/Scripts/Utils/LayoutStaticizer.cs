using UnityEngine;
using UnityEngine.UI;

public class LayoutStaticizer : MonoBehaviour, ScreenBecameActiveListener
{
    public bool staticizeOnScreenBecameActive = false;
    
    private void Start()
    {
        if (!staticizeOnScreenBecameActive) Staticize(transform);
    }
    
    public void OnScreenBecameActive()
    {
        if (staticizeOnScreenBecameActive) Staticize(transform);
    }
    
    public static void Staticize(Transform transform)
    {
        var gameObject = transform.gameObject;
        foreach (Transform child in gameObject.transform)
        {
            Staticize(child);
        }
        var contentSizeFitter = gameObject.GetComponent<ContentSizeFitter>();
        if (contentSizeFitter != null)
        {
            contentSizeFitter.enabled = false;
        }
        var layoutGroup = gameObject.GetComponent<HorizontalOrVerticalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.enabled = false;
        }
    }
    
}