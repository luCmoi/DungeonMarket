using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PersonnageController : MonoBehaviour {
    public Image image;
    public Text title;
    public Text stat0;
    public Text stat1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPnj(PnjBehavior pnj)
    {
        image.sprite = pnj.GetComponent<SpriteRenderer>().sprite;
        title.text = pnj.pnjName;
        stat0.text = "Life : " + pnj.life + "/" + pnj.lifeMax + "\nDamage : " + pnj.damage + "\nMoney : " + pnj.money;
        stat1.text = "Shop : " + pnj.shopMax + "\nAdventure : " + pnj.adventureMax + "\nQuest : " + pnj.questFinished + "\nKilled :" + pnj.monsterKilled;
    }
}
