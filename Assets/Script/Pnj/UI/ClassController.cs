using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassController : MonoBehaviour {
    public Image image;
    public Text title;
    public Text stat0;
    public Text stat1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetClass(Class classPnj)
    {
        image.sprite = classPnj.town.image;
        title.text = classPnj.nameClass;
        stat0.text = "Number : " + classPnj.membersActif + "\nSatisfaction : " + classPnj.level;
        stat1.text = "Quest : " + classPnj.questFinished + "\nKilled : " + classPnj.monsterKilled;
    }
}
