using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaseController : MonoBehaviour
{
    public Button button;
    public Image image;
    private Monster monster;
    private Dungeon dungeon;
    public GameObject pnjImage;
    private int tick;
    public int id;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            if (GameUtilities.Instance.tick != tick)
            {
                tick = GameUtilities.Instance.tick;
                if (dungeon != null)
                {
                    if (pnjImage.activeInHierarchy)
                    {
                        if (dungeon.visitor[id] == null)
                        {
                            pnjImage.SetActive(false);
                        }
                        else
                        {
                            pnjImage.GetComponent<RectTransform>().anchorMin = new Vector2(dungeon.visitor[id].quart * 0.25f, 0);
                            pnjImage.GetComponent<RectTransform>().anchorMax = new Vector2(dungeon.visitor[id].quart * 0.25f + 0.25f, 0.25f);
                        }
                    }
                    else if (dungeon.visitor[id] != null)
                    {
                        pnjImage.SetActive(true);
                        pnjImage.GetComponent<RectTransform>().anchorMin = new Vector2(dungeon.visitor[id].quart * 0.25f, 0);
                        pnjImage.GetComponent<RectTransform>().anchorMax = new Vector2(dungeon.visitor[id].quart * 0.25f + 0.25f, 0.25f);
                        pnjImage.GetComponent<Image>().sprite = dungeon.visitor[id].behavior.GetComponent<SpriteRenderer>().sprite;
                    }
                }
            }
        }
    }

    public void SetMonster(Monster monsterNew)
    {
        if (monsterNew == null)
        {
            monster = null;
            image.gameObject.SetActive(false);
        }
        else
        {
            monster = monsterNew;
            button.gameObject.SetActive(false);
            image.gameObject.SetActive(true);
            image.sprite = monster.image;
        }
    }

    public void SetDungeon(Dungeon dungeonNew)
    {
        dungeon = dungeonNew;
        pnjImage.SetActive(false);
        monster = null;
        if (dungeon.monsters[id] != null)
        {
            SetMonster(dungeon.monsters[id].monster);
        }
        else
        {
            if (id == 0)
            {
                ActivateButton();
            }
            else if (dungeon.monsters[id-1] != null)
            {
                ActivateButton();
            }
            else
            {
                DesactivateButton();
            }
            SetMonster(null);
        }
        GetComponent<Image>().sprite = dungeon.background[id];
    }

    public void ActivateButton()
    {
        button.interactable = true;
        button.GetComponent<Image>().color = Color.white;


    }
    public void DesactivateButton()
    {
        button.interactable = false;
        button.GetComponent<Image>().color = Color.grey;
    }
}
