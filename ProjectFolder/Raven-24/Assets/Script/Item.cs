using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "items", menuName = "Inventory/new Item")]
public class Item : ScriptableObject
{
    public string _title;
    public List<string> _info;
    public List<Item> _childs;
    // icon to show in inventory list
    public Sprite _icon;
    // object to instantiate
    public GameObject _mesh;
    // for counting weight of objects
    public float _weight;
    // for key objects
    public string _key;
    public void AssignItem(string title,string info, Sprite icon, GameObject mesh,List<Item>childs=null,float weight=0,string key="") {
        _title = title;
        _info[0]=info;
        _icon = icon;
        _mesh = mesh;
        _weight = weight;
        _childs = childs;
        _key = key;
    }

    public override string ToString()
    {
        return string.Format("Object type: Item, name = {0}, info ={1}, weight={2}, key = {3}",_title,_info[0],_weight,_key);
    }
    public Item DeepCopy() {
        return Instantiate<Item>(this);
    }
}
