using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnlockBigTileController : MonoBehaviour {
    public Text title;
    public Text price;
    public Button invade;
    public BigTileBehavior bigTile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetUnlock(BigTileBehavior bigTileNew)
    {
        bigTile = bigTileNew;
        title.text = "Unlock Territory - Difficulty : " + bigTile.monsters[0].power;
        price.text = bigTile.price.ToString();
        if (GameUtilities.Instance.research < bigTile.price || GameList.Instance.Monsters.Count <= 0)
        {
            invade.GetComponent<Image>().color = Color.grey;
            invade.interactable = false;
        }
        else
        {
            invade.GetComponent<Image>().color = Color.white;
            invade.interactable = true;
        }
    }

    public void Invade()
    {
        GameUtilities.Instance.ChangeResearch(-bigTile.price);
        UIController.Instance.ActivateFight(this);
    }
    public void End(bool victory)
    {
        if (victory)
        {
            bigTile.Activate();
            UIController.Instance.DesactivateMenu(5);
        }
        else
        {
            UIController.Instance.DesactivateMenu(5);
        }
    }
}
