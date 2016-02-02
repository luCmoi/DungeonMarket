using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FightController : MonoBehaviour {
    public List<MonsterInstance> monstersStat = new List<MonsterInstance>();
    public List<MonsterInstance> assaultStat = new List<MonsterInstance>();
    public int tick;
    public int pn;
    public int mo;
    public List<GameObject> empAssault = new List<GameObject>();
    public List<GameObject> empMonster = new List<GameObject>();
    public GameObject emp;
    public GameObject assaultEmp;
    public GameObject monsterEmp;
    // Use this for initialization
    void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if (GameUtilities.Instance.tick != tick)
        {
            tick = GameUtilities.Instance.tick;
            int monsterDamage = 0;
            int assaultDamage = 0;
            foreach (MonsterInstance monster in monstersStat)
            {
                monsterDamage += monster.monster.damage;
            }
            foreach (MonsterInstance assault in assaultStat)
            {
                assaultDamage += assault.monster.damage;
            }
            while (monsterDamage > 0 && assaultStat.Count > 0)
            {
                if (monsterDamage >= assaultStat[0].life)
                {
                    MonsterInstance tmp = assaultStat[0];
                    monsterDamage -= tmp.life;
                    assaultStat.Remove(tmp);
                    Destroy(empAssault[0]);
                    empAssault.RemoveAt(0);
                    tmp = null;
                    pn--;
                }
                else
                {
                    assaultStat[0].life -= monsterDamage;
                }
            }
            while (assaultDamage > 0 && monstersStat.Count > 0)
            {
                if (assaultDamage >= monstersStat[0].life)
                {
                    MonsterInstance tmp = monstersStat[0];
                    assaultDamage -= tmp.life;
                    monstersStat.Remove(tmp);
                    Destroy(empMonster[0]);
                    empMonster.RemoveAt(0);
                    tmp = null;
                    mo--;
                }
                else
                {
                    monstersStat[0].life -= assaultDamage;
                }
            }
            if (monstersStat.Count <= 0)
            {
                foreach (GameObject emp in empAssault)
                {
                    Destroy(emp);
                }
                UIController.Instance.inFight = false;
                assaultStat.Clear();
                UIController.Instance.FightEnded(true);
            }
            else if (assaultStat.Count <= 0)
            {
                foreach (GameObject emp in empMonster)
                {
                    Destroy(emp);
                }
                UIController.Instance.inFight = false;
                monstersStat.Clear();
                UIController.Instance.FightEnded(false);
            }
        }
    }

    public void LaunchFight(Monster[] monstersNew, Monster[] assaultNew)
    {
        UIController.Instance.inFight = true;
        pn = -1;
        mo = -1;
        foreach (Monster assault in assaultNew)
        {
            pn++;
            GameObject tmp = Instantiate(emp)as GameObject;
            tmp.GetComponent<Image>().sprite = assault.image;
            tmp.GetComponent<RectTransform>().parent = assaultEmp.GetComponent<RectTransform>();
            tmp.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f * (pn), 0);
            tmp.GetComponent<RectTransform>().anchorMax = new Vector2(0.2f * (1 + pn), 0.4f);
            tmp.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            tmp.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            empAssault.Add(tmp);
            assaultStat.Add(new MonsterInstance(assault));
        }
        foreach (Monster monster in monstersNew)
        {
            mo++;
            GameObject tmp = Instantiate(emp) as GameObject;
            tmp.GetComponent<Image>().sprite = monster.image;
            tmp.GetComponent<RectTransform>().parent = monsterEmp.GetComponent<RectTransform>();
            tmp.GetComponent<RectTransform>().anchorMin = new Vector2(0.2f * (mo), 0);
            tmp.GetComponent<RectTransform>().anchorMax = new Vector2(0.2f * (1 + mo), 0.4f);
            tmp.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            tmp.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            empMonster.Add(tmp);
            monstersStat.Add(new MonsterInstance(monster));

        }
        tick = GameUtilities.Instance.tick;
    }
}
