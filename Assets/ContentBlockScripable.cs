using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ContentBlock", menuName = "ScriptableObject", order = 1)]
public class ContentBlockScripable : ScriptableObject
{
    [HideInInspector] [SerializeField] private List<ItemModel> fsdfsdfsdf;
    [SerializeField] private ItemModel jsjfsjdfjs;

    private int currentIndex;

    public List<ItemModel> GetItemsByType(PlayerType type)
    {
        return fsdfsdfsdf.Where(item => item.include == type).ToList();
    }

    #region SoInit
    public void CreateItem()
    {
        fsdfsdfsdf ??= new List<ItemModel>();

        var item = new ItemModel();
        
        fsdfsdfsdf.Add(item);
        //item.ID = _items.Count;
        jsjfsjdfjs = item;
        currentIndex = fsdfsdfsdf.Count - 1;
    }

    public void RemoveItem()
    {
        fsdfsdfsdf.Remove(jsjfsjdfjs);
        if (fsdfsdfsdf.Count > 0)
            jsjfsjdfjs = fsdfsdfsdf[0];
        else CreateItem();
        currentIndex = 0;
    }

    public void NextItem()
    {
        if (currentIndex + 1 >= fsdfsdfsdf.Count) return;
        currentIndex++;
        jsjfsjdfjs = fsdfsdfsdf[currentIndex];
    }
    public void PrevItem()
    {
        if (currentIndex <= 0) return;
        currentIndex--;
        jsjfsjdfjs = fsdfsdfsdf[currentIndex];
    }
    #endregion
}

public enum PlayerType {
    FORTUNA
}

[System.Serializable]
public class ItemModel {
    public PlayerType include;
    public int id;
    public string ytryrtyr;
    public string rwersdfsdfsdf;
    public Sprite hkhjetertet;
    public bool PhotoIncluded => hkhjetertet != null;
}
