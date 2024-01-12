using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContentControl : MonoBehaviour
{
    [SerializeField] private TMP_Text dfgdfgdfgd;
    [SerializeField] private TMP_Text werwersfsdf;
    [SerializeField] private Image khktutyurty;

    [SerializeField] private ContentBlockScripable rtertergdfgdfg;

    [SerializeField] private GameObject qweqwasfsfdsdf;
    [SerializeField] private GameObject uikhjfhfghfh;

    private List<ItemModel> fsdfjsjd;
    private int roerosdf;

    private float _defaultHeight;
    private float _yPosition;
    [SerializeField] private RectTransform _globScrollRect;

    private const float MULTIPLIER = 3f;

    private void Awake()
    {
        _yPosition = _globScrollRect.offsetMin.y;
        Debug.Log(_yPosition);
    }

    public void ClickNext()
    {
        if (roerosdf == fsdfjsjd.Count - 1)
        {
            roerosdf = 0;
            qweqwasfsfdsdf.SetActive(false);
            uikhjfhfghfh.SetActive(true);
            return;
        }

        roerosdf++;
        Htertsfsdf();
    }

    public void Gtrertsdfgdfgdfg(int id)
    {
        roerosdf = 0;

        Nretetfs type = (Nretetfs)id;
        fsdfjsjd = rtertergdfgdfg.GetItemsByType(type);
    }

    public void Htertsfsdf()
    {
        dfgdfgdfgd.text = fsdfjsjd[roerosdf].ytryrtyr;
        
        khktutyurty.sprite = fsdfjsjd[roerosdf].hkhjetertet;
        werwersfsdf.text = fsdfjsjd[roerosdf].rwersdfsdfsdf;

        //float bottom = yPosition - height * 0.5f;
        _globScrollRect.offsetMin = fsdfjsjd[roerosdf].PhotoIncluded
            ? new Vector2(_globScrollRect.offsetMin.x, _yPosition)
            : new Vector2(_globScrollRect.offsetMin.x, 0);
        
        khktutyurty.gameObject.SetActive(fsdfjsjd[roerosdf].PhotoIncluded);
        if(khktutyurty.sprite == null) return;
        khktutyurty.SetNativeSize();
        
        float w = khktutyurty.sprite.rect.width / khktutyurty.pixelsPerUnit;
        float h = khktutyurty.sprite.rect.height / khktutyurty.pixelsPerUnit;

        var rect = khktutyurty.rectTransform.sizeDelta;
        w *= MULTIPLIER;
        h *= MULTIPLIER;
        khktutyurty.rectTransform.sizeDelta = new Vector2(w, h);
    }

    public void Exit()
    {
        Application.Quit();
    }
}