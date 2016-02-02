using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
   public float barDisplay; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    public Building building;
    public PnjBehavior pnj;
    public int differentCase;
     void OnGUI()
    {
        pos = GetComponent<RectTransform>().position;
        if (differentCase == 0)
        {
            GetComponent<RectTransform>().pivot = new Vector2(0, -10);
        }
        size = new Vector2(GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height);
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), GUIContent.none);
        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), GUIContent.none);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    public void SetQuestGiver(Building buildingNew)
    {
        building = buildingNew;
    }

    public void SetPnj(PnjBehavior pnjNew)
    {
        pnj = pnjNew;
    }

    void FixedUpdate()
    {
        if (building != null)
        {
            barDisplay = building.xp / (float)building.xpMax[building.level];
        }else if (pnj != null)
        {
            barDisplay = pnj.xp / (float)pnj.xpMax[pnj.level];
        }
    }
}

