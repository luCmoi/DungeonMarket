using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Band : MonoBehaviour {
    public Text title;
    public Text body;
    public Image image;
    public bool activated;
    public int queue;
    public List<Sprite> imageQueue = new List<Sprite>();
    public List<string> titleQueue = new List<string>();
    public List<string> bodyQueue = new List<string>();

    public float timer;
    public float lastTimer;
    public float timerMax;
    public float speed;
    // Use this for initialization
    void Start () {
        speed = 0.15f / 1.00f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (activated)
        {
            timer += Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        if (activated)
        {
            if (timer <= 1)
            {
               GetComponent<RectTransform>().anchorMin = GetComponent<RectTransform>().anchorMin - new Vector2(0, speed * (timer - lastTimer));
               GetComponent<RectTransform>().anchorMax = GetComponent<RectTransform>().anchorMax - new Vector2(0, speed * (timer - lastTimer));
            }
            else if (timer <= 3)
            {
                GetComponent<RectTransform>().anchorMin = new Vector2(0,0.85f);
                GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            }
            else if (timer <= 4)
            {
                GetComponent<RectTransform>().anchorMin = GetComponent<RectTransform>().anchorMin + new Vector2(0, speed * (timer - lastTimer));
                GetComponent<RectTransform>().anchorMax = GetComponent<RectTransform>().anchorMax + new Vector2(0, speed * (timer - lastTimer));
            }
            else
            {
                GetComponent<RectTransform>().anchorMin = new Vector2(0,1);
                GetComponent<RectTransform>().anchorMax = new Vector2(1, 1.15f);
                if (queue > 0)
                {
                    queue--;
                    timer = 0;
                    image.sprite = imageQueue[0];
                    title.text = titleQueue[0];
                    body.text = bodyQueue[0];
                    imageQueue.Remove(image.sprite);
                    titleQueue.Remove(title.text);
                    bodyQueue.Remove(body.text);

                }
                else
                {
                    activated = false;
                }
            }
            lastTimer = timer;
        }
    }

    public void Activate(Sprite imageNew, string titleNew, string bodyNew)
    {
        if (!activated)
        {
            activated = true;
            lastTimer = 0;
            timer = 0;
            image.sprite = imageNew;
            title.text = titleNew;
            body.text = bodyNew;
        }
        else
        {
            queue++;
            imageQueue.Add(imageNew);
            titleQueue.Add(titleNew);
            bodyQueue.Add(bodyNew);
        }
    }
}
