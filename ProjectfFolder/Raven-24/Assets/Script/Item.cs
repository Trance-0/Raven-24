using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "items", menuName = "Inventory/new Item")]
public class Item : ScriptableObject
{
    public string _title;
    public string _info;
    // icon to show in inventory list
    public Sprite _icon;
    // object to instantiate
    public GameObject _mesh;
    // for counting weight of objects
    public float _weight;
    // for key objects
    public string _key;
    public Item(string title,string info, Sprite icon, GameObject mesh) {
        _title = title;
        _info = info;
        _icon = icon;
        _mesh = mesh;
        _weight = 0;
        _key = "";
    }
    public Item(string title, string info, Sprite icon, GameObject mesh,float weight)
    {
        _title = title;
        _info = info;
        _icon = icon;
        _mesh = mesh;
        _weight = weight;
        _key = "";
    }
    public Item(string title, string info, Sprite icon, GameObject mesh,string key)
    {
        _title = title;
        _info = info;
        _icon = icon;
        _mesh = mesh;
        _weight = 0;
        _key = key;
    }
    public Item(string title, string info, Sprite icon, GameObject mesh,float weight,string key)
    {
        _title = title;
        _info = info;
        _icon = icon;
        _mesh = mesh;
        _weight = weight;
        _key = key;
    }

    public override string ToString()
    {
        return string.Format("Object type: Item, name = {0}, info ={1}, weight={2}, key = {3}",_title,_info,_weight,_key);
    }
    public Item DeepCopy() {
        return new Item(_title,_info,_icon,_mesh,_weight,_key);
    }
}
