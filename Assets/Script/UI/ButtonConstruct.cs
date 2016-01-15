using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class ButtonConstruct : MonoBehaviour {
    public GameObject building;
    public Text nameConstruct;
    public Text price;
    private float sizeName = 0.02f;
    private float sizePrice = 0.02f;

	// Use this for initialization
	void Start () {
        nameConstruct.fontSize = CalculFont(sizeName);
        price.fontSize = CalculFont(sizePrice);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
                GameUtilities.Instance.ActiveConstructing();
                GameUtilities.Instance.building = building;
                UIController.Instance.DesactivateMenu(0);
        }

    int CalculFont(float fontSize)
    {
        return (int)(Screen.width * fontSize);
    }

}
