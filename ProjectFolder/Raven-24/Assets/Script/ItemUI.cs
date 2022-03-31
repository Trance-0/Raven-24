using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject self;
    public Image icon;
    public Button listener;
    public GameObject highlightEffect;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void SetSelfAsSelected() {
        if (inventoryManager.selected!=null&&inventoryManager.selected.GetComponent<ItemUI>().item.Equals(item))
        {
            inventoryManager.ShowDetail(true);
        }
        else
        {
            if (inventoryManager.selected != null)
            {
                inventoryManager.selected.GetComponent<ItemUI>().highlightEffect.SetActive(false);
            }
            inventoryManager.selected = self;
            self.GetComponent<ItemUI>().highlightEffect.SetActive(true);
        }
    }
}
