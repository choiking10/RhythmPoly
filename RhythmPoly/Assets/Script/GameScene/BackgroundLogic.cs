using UnityEngine;
using System.Collections;

public class BackgroundLogic : MonoBehaviour
{
    public Transform bg;
    public Transform downbg;

    public SpriteRenderer[] order;    //bg
    
    public Transform pat;   // pattern

    public SpriteRenderer pat_sr;
    public Sprite[] sprites;

    public float stime = 1;

    private Color[] colors = { new Color((float)0x55/0xff, (float)0x67/0xff, (float)0x89/0xff), 
                                 new Color((float)0xff/0xff, (float)0xc0/0xff, (float)0xb1/0xff), 
                                 new Color((float)0x7b/0xff, (float)0xbd/0xff, (float)0xef/0xff),
                                 new Color((float)0xff/0xff, (float)0x99/0xff, (float)0x66/0xff),
                                 new Color((float)0x9d/0xff, (float)0xed/0xff, (float)0xbf/0xff),
                                 new Color((float)0xf4/0xff, (float)0xac/0xff, (float)0xda/0xff), 
                                 new Color((float)0xab/0xff, (float)0xaa/0xff, (float)0xec/0xff), 
                                 new Color((float)0x62/0xff, (float)0xcc/0xff, (float)0x86/0xff), 
                                 new Color((float)0x56/0xff, (float)0x7c/0xff, (float)0x89/0xff), 
                                 new Color((float)0xfc/0xff, (float)0xea/0xff, (float)0x9f/0xff)
                             };

    public SpriteRenderer[] BackgroundColors = new SpriteRenderer[2];

    // downbg localposition 가져옴
    float GetDownBg() {
        return downbg.localPosition.y;
    }
    // 색깔 대충 같은지 체크해준다.
    bool EqaulIsColored(Color a, Color b) {
        if (((int)((a.r*0xff) / 0x10) == (int)((b.r*0xff) / 0x10))
            && ((int)((a.g*0xff) / 0x10) == (int)((b.g*0xff) / 0x10))
            && ((int)((a.b*0xff) / 0x10) == (int)((b.b*0xff) / 0x10))) {
            return true;
        }
        return false;
    }
    // 랜덤 색깔 세팅해줌
    void SetRandomColor() {
        int idx = Random.Range(0, 10);

        for (int i = 0; i < 2; i++)
        {
            //if (colors[idx].Equals(BackgroundColors[i].color))
            //{
            //    idx = Random.Range(0, 10);
            //    i = 0;
            //}
            if (EqaulIsColored(colors[idx], BackgroundColors[i].color)) {
                idx = Random.Range(0, 10);
                i = 0;
            }
        }

        for (int i = 0; i < order.Length; i++)
        {
            order[i].color = colors[idx];
        }
        pat_sr.color = colors[idx];
    }

    // Use this for initialization
	void Start () {
        SetRandomColor();

        int idx = Random.Range(0, 5);
        pat_sr.sprite = sprites[idx];
    }
	
	// Update is called once per frame
	void Update () {
        
        StartCoroutine(SleepPat(stime));
        StartCoroutine(SleepBg(stime));
        //        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y-0.01f, this.transform.position.z);
        //       this.transform.position = pos;
	}

    // 패턴 s 초마다 호출
    IEnumerator SleepPat(float s)
    {
        float y = pat.localPosition.y;
     
        // 부모 배경이 -15 이하이면 패턴을 아래로 안보이게 만든다.   
        if (bg.localPosition.y < -15) {
            y = -32;
        } else if (bg.localPosition.y < 0) {    // 부모 배경이 화면에 보이면 아래로 조금씩 내려가게 하자
            y -= 0.5f;
        } else {                                // 부모 배경이 위에 있을 때는 패턴이 아래로 내려가지 않도록 고정
            y = 15;
        }

        // 배경이 특정 위치에 도달했을 때 패턴을 랜덤으로 결정해준다.
        if ((0.0f > bg.localPosition.y) && (bg.localPosition.y > -0.2f)
            || (-6.0f > bg.localPosition.y) && (bg.localPosition.y > -6.2f))
        {
            int idx = Random.Range(0, 5);
            pat_sr.sprite = sprites[idx];
            y = 15;
        }

        Vector3 pos = new Vector3(0, y, 0);
        
        yield return new WaitForSeconds(s);
        pat.localPosition = pos;
    }

    // 배경 s 초마다 호출
    IEnumerator SleepBg(float s)
    {
        float y = bg.localPosition.y;

        // 아래 bg + 12에 위치시켜준다.
        if (y < -18)
        {
            //y = 22;
            y = GetDownBg() + 12;
            bg.localPosition = new Vector3(0, y, 0);
            SetRandomColor();

            // 맨 위에 있기 때문에 맨 위로 올려줌
            for (int i = 0; i < order.Length; i++)
            {
                order[i].sortingOrder = 2;
            }
        }
        else if (y < -6) {
            // 아래 배경이기 때문에 정렬을 맨 밑
            for (int i = 0; i < order.Length; i++)
            {
                order[i].sortingOrder = 0;
            }
        }
        else if (y < 6) {
            for (int i = 0; i < order.Length; i++)
            {
                order[i].sortingOrder = 1;
            }
        }

        // 0.2 만큼 아래로 내려감
        Vector3 pos = new Vector3(0, y - 0.2f, 0);
     //   Debug.Log(pos);
        yield return new WaitForSeconds(s);
        bg.localPosition = pos;
    }
}
