using UnityEngine;
using System.Collections.Generic;

public class PnjPopupInfo : MonoBehaviour {
    public TextMesh text;
    public float lifeTime;
    public float yUpSpeed;
    public float yUpMax;
    public float lastLife;
    public float life;
    public float initX;
    public float initY;
    public List<GameObject> list;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public bool activated;

	// Use this for initialization
	void Start () {
        gameObject.transform.Translate(new Vector3(initX, initY));
        yUpSpeed = yUpMax / lifeTime;
        activated = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            life += Time.deltaTime;
        }
        
	}
    void FixedUpdate()
    {
        if (activated)
        {
            gameObject.transform.Translate(new Vector3(0, yUpSpeed * (life - lastLife)));
            lastLife = life;
            if (life >= lifeTime)
            {
                list.Remove(gameObject);
                Destroy(gameObject);
            }
        }else
        {
            if (list.Count > 0 && list[0].GetComponent<PnjPopupInfo>() == this)
            {
                activated = true;
                spriteRenderer.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }else if (list.Count > 1 && list[1].GetComponent<PnjPopupInfo>() == this && list[0].GetComponent<PnjPopupInfo>().life >= list[0].GetComponent<PnjPopupInfo>().lifeTime/1.5f)
            {
                activated = true;
                spriteRenderer.gameObject.SetActive(true);
                text.gameObject.SetActive(true);

            }
        }
    }

    public void setText(int type, string textNew, List<GameObject> listNew)
    {
        list = listNew;
        spriteRenderer.sprite = sprites[type];
        text.text = textNew;
    }
}
