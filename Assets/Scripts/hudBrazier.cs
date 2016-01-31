using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class hudBrazier : MonoBehaviour {

    public GameObject imagePrefab;
    public GameObject canvas;

    public Sprite litTex;
    public Sprite unlitTex;

    private List<GameObject> icons;

    private int noLit;
    private int noTotal;
    private int setLit = 0;

	void Start () {
        noLit = GameManager.Instance.LitBraziers;
        noTotal = GameManager.Instance.Braziers;
        icons = new List<GameObject>();
        

        for (int i=0; i<noTotal; i++)
        {
            GameObject newIcon = Instantiate(imagePrefab);
            newIcon.transform.SetParent(canvas.gameObject.transform, false);
            newIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-i * newIcon.GetComponent<RectTransform>().rect.width, 0);
            icons.Add(newIcon);
        }
    }
	
	void Update () {
        setLitTextures();
        noLit = GameManager.Instance.LitBraziers;
    }

    void setLitTextures()
    {
        if (setLit!=noLit)
        {
            for(int i=0;i<noTotal; i++)
            {
                if (i < noLit) icons[i].GetComponent<UnityEngine.UI.Image>().sprite = litTex;
                else icons[i].GetComponent<UnityEngine.UI.Image>().sprite = unlitTex;
            }
            setLit = noLit;
        }
    }
}
