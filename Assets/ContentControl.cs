using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContentControl : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private TMP_Text _playerInfoText;
    [SerializeField] private Image _playerNamePhoto;

    [SerializeField] private ContentBlockScripable _script;

    [SerializeField] private GameObject _go;
    [SerializeField] private GameObject _go2;

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
            _go.SetActive(false);
            _go2.SetActive(true);
            return;
        }

        roerosdf++;
        LoadBlock();
    }

    public void LoadList(int id)
    {
        roerosdf = 0;

        PlayerType type = (PlayerType)id;
        fsdfjsjd = _script.GetItemsByType(type);
    }

    public void LoadBlock()
    {
        _playerNameText.text = fsdfjsjd[roerosdf].ytryrtyr;
        
        _playerNamePhoto.sprite = fsdfjsjd[roerosdf].hkhjetertet;
        _playerInfoText.text = fsdfjsjd[roerosdf].rwersdfsdfsdf;

        //float bottom = yPosition - height * 0.5f;
        _globScrollRect.offsetMin = fsdfjsjd[roerosdf].PhotoIncluded
            ? new Vector2(_globScrollRect.offsetMin.x, _yPosition)
            : new Vector2(_globScrollRect.offsetMin.x, 0);
        
        _playerNamePhoto.gameObject.SetActive(fsdfjsjd[roerosdf].PhotoIncluded);
        if(_playerNamePhoto.sprite == null) return;
        _playerNamePhoto.SetNativeSize();
        
        float w = _playerNamePhoto.sprite.rect.width / _playerNamePhoto.pixelsPerUnit;
        float h = _playerNamePhoto.sprite.rect.height / _playerNamePhoto.pixelsPerUnit;

        var rect = _playerNamePhoto.rectTransform.sizeDelta;
        w *= MULTIPLIER;
        h *= MULTIPLIER;
        _playerNamePhoto.rectTransform.sizeDelta = new Vector2(w, h);
    }

    public void Exit()
    {
        Application.Quit();
    }
}