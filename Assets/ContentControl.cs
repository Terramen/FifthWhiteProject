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

    private List<ItemModel> _currentList;
    private int _currentId;

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
        if (_currentId == _currentList.Count - 1)
        {
            _currentId = 0;
            _go.SetActive(false);
            _go2.SetActive(true);
            return;
        }

        _currentId++;
        LoadBlock();
    }

    public void LoadList(int id)
    {
        _currentId = 0;

        PlayerType type = (PlayerType)id;
        _currentList = _script.GetItemsByType(type);
    }

    public void LoadBlock()
    {
        _playerNameText.text = _currentList[_currentId].playerName;
        
        _playerNamePhoto.sprite = _currentList[_currentId].playerPhoto;
        _playerInfoText.text = _currentList[_currentId].playerInfo;

        //float bottom = yPosition - height * 0.5f;
        _globScrollRect.offsetMin = _currentList[_currentId].PhotoIncluded
            ? new Vector2(_globScrollRect.offsetMin.x, _yPosition)
            : new Vector2(_globScrollRect.offsetMin.x, 0);
        
        _playerNamePhoto.gameObject.SetActive(_currentList[_currentId].PhotoIncluded);
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