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

    public void ClickNext() {
        if (_currentId == _currentList.Count - 1) {
            _currentId = 0;
            _go.SetActive(false);
            _go2.SetActive(true);
            return;
        }
        _currentId++;
        LoadBlock();
    }

    public void LoadList(int id) {
        _currentId = 0;

        PlayerType type = (PlayerType)id;
        _currentList = _script.GetItemsByType(type);
    }
    
    public void LoadBlock() {
        _playerNameText.text = _currentList[_currentId].playerName;
        _playerNamePhoto.sprite = _currentList[_currentId].playerPhoto;
        _playerInfoText.text = _currentList[_currentId].playerInfo;
    }

    public void Exit() {
        Application.Quit();
    }

}
