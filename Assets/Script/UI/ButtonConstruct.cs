using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class ButtonConstruct : MonoBehaviour {
    public GameObject building;
    public Text name;
    public Text price;
    private float sizeName = 0.02f;
    private float sizePrice = 0.02f;

	// Use this for initialization
	void Start () {
        name.fontSize = CalculFont(sizeName);
        price.fontSize = CalculFont(sizePrice);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
                GameUtilities.Instance.ActiveConstructing();
                GameUtilities.Instance.building = building;
        GameUtilities.Instance.DesactivateMenu();
        }

    int CalculFont(float fontSize)
    {
        return (int)(Screen.width * fontSize);
    }

}
