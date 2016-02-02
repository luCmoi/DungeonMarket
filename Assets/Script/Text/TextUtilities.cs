using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextUtilities : MonoBehaviour {
    public float[] size;
    public static TextUtilities Instance;
    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        else
        {
            Instance = this;
        }
    }


    public void SetSize(Text textSet, int sizeSet)
    {
        textSet.fontSize = (int)(Screen.width * size[sizeSet]);
    }
}
