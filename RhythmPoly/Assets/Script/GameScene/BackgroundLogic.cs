﻿using UnityEngine;
using System.Collections;

public class BackgroundLogic : MonoBehaviour
{
    public Transform bg;
    public SpriteRenderer order;    //bg
    
    public Transform pat;   // pattern

    public SpriteRenderer pat_sr;
    public Sprite[] sprites;

    public float stime = 1;

    private Color[] colors = { new Color((float)0x55/0xff, (float)0x67/0xff, (float)0x89/0xff), 
                                 new Color((float)0xff/0xff, (float)0xc0/0xff, (float)0xb1/0xff), 
                                 new Color((float)0x7b/0xff, (float)0xbd/0xff, (float)0xef/0xff),
                                 new Color((float)0xff/0xff, (float)0x99/0xff, (float)0x66/0xff),
                                 new Color((float)0x9d/0xff, (float)0xed/0xff, (float)0xbf/0xff),
                                 new Color((float)0xf9/0xff, (float)0x41/0xff, (float)0x71/0xff), 
                                 new Color((float)0x6d/0xff, (float)0x32/0xff, (float)0x29/0xff), 
                                 new Color((float)0xae/0xff, (float)0xa7/0xff, (float)0xc1/0xff), 
                                 new Color((float)0x67/0xff, (float)0x99/0xff, (float)0x7f/0xff), 
                                 new Color((float)0xff/0xff, (float)0xce/0xff, (float)0x55/0xff)
                             };

    public SpriteRenderer[] BackgroundColors = new SpriteRenderer[2];


    // 랜덤 색깔 세팅해줌
    void SetRandomColor() {
        int idx = Random.Range(0, 10);

        for (int i = 0; i < 2; i++)
        {
            if (colors[idx].Equals(BackgroundColors[i].color))
            {
                idx = Random.Range(0, 10);
                i = 0;
            }
        }

        order.color = colors[idx];
        pat_sr.color = colors[idx];
    }

    // Use this for initialization
	void Start () {
        SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
        
        StartCoroutine(SleepPat(stime));
        StartCoroutine(SleepBg(stime));
        //        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y-0.01f, this.transform.position.z);
        //       this.transform.position = pos;
	}

    IEnumerator SleepPat(float s)
    {
        float y = pat.localPosition.y;
        if (!(bg.localPosition.y > -11))
            y -= 0.4f;
        if ((-11 > bg.localPosition.y) && (bg.localPosition.y > -11.2)) {
            int idx = Random.Range(0, 5);
            pat_sr.sprite = sprites[idx];
            y = 20;
        }

        Vector3 pos = new Vector3(0, y, 0);
        
        yield return new WaitForSeconds(s);
        pat.localPosition = pos;
    }
    IEnumerator SleepBg(float s)
    {
        float y = bg.localPosition.y;

        if (y < -31)
        {
            order.sortingOrder = 2;
            y = 29;
            SetRandomColor();
        }
        else if (y < -11) {
            order.sortingOrder = 0;
        }
        else if (y < 9) {
            order.sortingOrder = 1;
        }
        Vector3 pos = new Vector3(0, y - 0.1f, 0);
     //   Debug.Log(pos);
        yield return new WaitForSeconds(s);
        bg.localPosition = pos;
    }
}