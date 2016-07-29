using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BackgroundManager  : MonoBehaviour 
{
    public float downframe;
    public float unittime;
    public float befTime;
    public float downPatMulti;
    public float limit;
    public GameObject initpos;
    public GameObject endpos;

    public GameObject[] bglist;
    public GameObject[] patlist;
    public GameObject bgcontainer;
    public static Sprite[] PatSprite;
    public static Sprite[] bgSprite;

    public static BackgroundInfo[] backInfo;
    void Start()
    {
        befTime = Time.fixedTime;
        UnPackBackgroundData();
    }
    void FixedUpdate()
    {
        
        if (Time.fixedTime >= befTime + unittime) // unittime에 한번씩  실행
        {
            befTime = Time.fixedTime;
            BgDownSeq();
            PatDownSeq();
        }
        RandomGen();
        
    }
    public GameObject GetTargetBG()
    {
        return bgcontainer.GetComponentsInChildren<Image>()[0].gameObject;
    }
    //단독 패턴 내려가는 로직
    void PatDownSeq()
    {
        foreach (GameObject pat in patlist)
        {
            Vector3 pos = pat.GetComponent<RectTransform>().localPosition;
            pos.y -= downPatMulti;
            if (pos.y < -1500f) pat.SetActive(false);
            pat.GetComponent<RectTransform>().localPosition = pos;
        }
    }
    //그 외에 다른 것들이 내려가는 로직
    static int countbg = 0;
    void BgDownSeq()
    {
        Vector3 epos = endpos.GetComponent<RectTransform>().position;
        Vector3 spos = initpos.GetComponent<RectTransform>().position;
        countbg++;
        if (countbg < 0) countbg = 0;
        foreach (GameObject pat in bglist)
        {
            Vector3 pos = pat.GetComponent<RectTransform>().position;
            pos.y -= downframe * 2;
            foreach (Image sp in pat.GetComponentsInChildren<Image>())
            {
                if (sp.name.CompareTo("bottom") == 0)
                {
                    sp.sprite = bgSprite[countbg % bgSprite.Length];
                    break;
                }
            }
            if (pos.y < epos.y)
            {
                pos = spos;
                ChangeSeq(pat);
                pat.transform.SetAsLastSibling();
            }
            pat.GetComponent<RectTransform>().position = pos;
        }
    }
    bool EqaulIsColored(Color a, Color b)
    {
        if (((int)((a.r * 0xff) / 0x10) == (int)((b.r * 0xff) / 0x10))
            && ((int)((a.g * 0xff) / 0x10) == (int)((b.g * 0xff) / 0x10))
            && ((int)((a.b * 0xff) / 0x10) == (int)((b.b * 0xff) / 0x10)))
        {
            return true;
        }
        return false;
    }
    int RandomPick()
    {
        int pidx = 0;
        int count = 0;
        while (true)
        {
            count++;
            if (count > 1000)
            {
                break;
            }
            pidx = Random.Range(0, 100);
            bool flag = true;
            foreach (Image img in GetComponentsInChildren<Image>())
            {
                if (EqaulIsColored(img.color, ColorPicker.GetColor(pidx)))
                {
                    flag = false;
                    break;
                }
            }
            if (flag) break;
        }
        return pidx;
    }
    void ChangeSeq(GameObject bg)
    {
        int pidx = RandomPick();
        foreach (Image img in bg.GetComponentsInChildren<Image>())
        {
            img.color = ColorPicker.GetColor(pidx);
        }
    }
    GameObject GetUnusedPat()
    {
        foreach (GameObject pat in patlist)
        {
            if (!pat.activeSelf) return pat;
        }
        return null;
    }
    static float NextpatGen;

    void RandomGen()
    {
        if (NextpatGen <= Time.fixedTime)
        {
            GameObject next = GetUnusedPat();
            if (next == null) return;
            GameObject tbg = GetTargetBG().transform.parent.gameObject;
            if (tbg.GetComponent<RectTransform>().localPosition.y >= -limit)
            {
                NextpatGen = Time.fixedTime + Random.Range(3.0f, 10.0f);
                next.SetActive(true);
                next.GetComponent<Image>().sprite = PatSprite[Random.Range(0, PatSprite.Length)];
                next.transform.position = next.transform.parent.position;
                next.GetComponentInChildren<Image>().color = tbg.GetComponentInChildren<Image>().color;
            }
        }
    }
    
    void initBgStaticMember()
    {
        bgSprite = new Sprite[3];
        PatSprite = new Sprite[5];

        for (int i = 0; i < 3; i++)
            bgSprite[i] = Resources.Load<Sprite>("bg" + (i + 1));
        
        for (int i = 0; i < 5; i++)
            PatSprite[i] = Resources.Load<Sprite>("pattern-" + (i + 1));

    }
    void initBground()
    {
        initBgStaticMember();

        Image[] imgs = bgcontainer.GetComponentsInChildren<Image>();
        
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 1)
            {
                imgs[i].sprite = bgSprite[i / 2];
            }
        }
        for (int i = 0; i < 3; i++) ChangeSeq(bglist[i]);
    }
    void PackBackgroundData()
    {
        backInfo = new BackgroundInfo[6];
        Image[] imgs = bgcontainer.GetComponentsInChildren<Image>();
        Debug.Log(imgs.Length);
        for (int i = 0; i < 6; i++)
        {
            backInfo[i] = new BackgroundInfo();
            backInfo[i].col = imgs[i].color;
            backInfo[i].source = imgs[i].sprite;
            backInfo[i].yval =
                   imgs[i].transform.parent.GetComponent<RectTransform>().localPosition.y;
        }
    }
    void UnPackBackgroundData()
    {
        if (backInfo == null)
        {
            initBground();
            return;
        }
        Image[] imgs = bgcontainer.GetComponentsInChildren<Image>();
        for (int i = 0; i < 6; i++)
        {
            imgs[i].color  = backInfo[i].col;
            imgs[i].sprite = backInfo[i].source;
            RectTransform trans = imgs[i].transform.parent.GetComponent<RectTransform>();
            trans.localPosition = new Vector3(0, backInfo[i].yval, 0);
       
        }
    }
    void OnDestroy()
    {
        PackBackgroundData();
    }
}