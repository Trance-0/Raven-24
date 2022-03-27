using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public ItemUI self;
    public Image icon;
    public Button listener;
    public Image highlightEffect;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSelfAsSelected() {
        if (inventoryManager.selected.item.Equals(self.item))
        {
            inventoryManager.ShowDetail(true);
        }
        else
        {
            inventoryManager.selected = self;
        }
    }
}
