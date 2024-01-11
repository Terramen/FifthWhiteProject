using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContentBlock", menuName = "ScriptableObject", order = 1)]
public class ContentBlockScripable : ScriptableObject
{
    [HideInInspector] [SerializeField] private List<ItemModel> _items;
    [SerializeField] private ItemModel currentItem;

    private int currentIndex;

    public List<ItemModel> Items => _items;

    private Dictionary<string, List<ItemModel>> _sortedItems;

    private void OnEnable()
    {
        _sortedItems = new Dictionary<string, List<ItemModel>>();
    }

    public List<ItemModel> GetItemsByType(PlayerType type) {

        var list = new List<ItemModel>();

        foreach (var item in _items)
        {
            if (item.playerType == type)
            {
                list.Add(item);
            }
        }

        return list;
    }

    #region SoInit
    public void CreateItem()
    {
        if (_items == null)
        {
            _items = new List<ItemModel>();
        }

        var item = new ItemModel();
        
        _items.Add(item);
        //item.ID = _items.Count;
        currentItem = item;
        currentIndex = _items.Count - 1;
    }

    public void RemoveItem()
    {
        _items.Remove(currentItem);
        if (_items.Count > 0)
            currentItem = _items[0];
        else CreateItem();
        currentIndex = 0;
    }

    public void NextItem()
    {
        if (currentIndex + 1 < _items.Count)
        {
            currentIndex++;
            currentItem = _items[currentIndex];
        }
    }
    public void PrevItem()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            currentItem = _items[currentIndex];
        }
    }
    #endregion
}

public enum PlayerType {
    FORWARD, MIDFIELDER, DEFENDER, GOALKEEPER
}

[System.Serializable]
public class ItemModel {
    public PlayerType playerType;
    public int id;
    public string playerName;
    public string playerInfo;
    public Sprite playerPhoto;
}
