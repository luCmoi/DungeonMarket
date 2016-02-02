using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class ButtonConstruct : MonoBehaviour {
    public GameObject building;
    public Text nameConstruct;
    public Text price;
    public Image image;
    public GameObject grey;
    public bool active;
	// Use this for initialization
	void Start () {
        nameConstruct.text = building.GetComponent<Building>().nameBuilding;
        price.text = building.GetComponent<Building>().price.ToString();
        image.sprite = building.GetComponent<Building>().image;
        if (building.GetComponent<Building>().locked)
        {
            GetComponent<Button>().interactable = false;
            grey.SetActive(true);
            active = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
            grey.SetActive(false);
            active = true;
        }
    }
	
    void FixedUpdate()
    {
        if (!active)
        {
            if (!building.GetComponent<Building>().locked)
            {
                GetComponent<Button>().interactable = true;
                grey.SetActive(false);
                active = true;
            }
        }
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

}
