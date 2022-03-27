using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // global config
    public PlayerMove playerMove;
    public DataManager dataManager;

    //Inventory UI
    public GameObject self;
    public Text title;

    //Detail shower UI
    public GameObject detailWindow;
    public Image detailImage;
    public Text detailTitle;
    public Text detailInfo;

    // ALL THE MESH IN ITEM MUST HAVE ITEMHANDLE TO INSTANTIATE THEM TO 3D SPACE
    public List<Item> items;
    // this is used to instantiate object in 2D list;
    public ItemUI itenUIPF;

    public ItemUI selected;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitializeInventoryList",1f);
        ShowDetail(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void UpdateItem() {
        for (int i = self.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(self.transform.GetChild(i).gameObject);
        }
        foreach (Item i in items)
        {
            CreateItemUI(i);
        }
    }
    public void UpdateChildItem(Item parentItem)
    {
        for (int i = self.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(self.transform.GetChild(i).gameObject);
        }
        foreach (Item i in parentItem._childs)
        {
            CreateItemUI(i);
        }
    }
    public void CreateItemUI(Item i) {
        ItemUI newItemUI = Instantiate(itenUIPF, self.transform);
        newItemUI.self = newItemUI;
        newItemUI.inventoryManager = self.GetComponent<InventoryManager>();
        newItemUI.item = i;
        newItemUI.icon.sprite = i._icon;
    }

    public void ShowDetail(bool state)
    {
        detailInfo.text = selected.item._info;
        detailTitle.text = selected.item._title;
        detailImage.sprite = selected.item._icon;
            detailWindow.SetActive(state);
            detailWindow.SetActive(state);
            if (state&&selected.item._childs!=null)
            {
                UpdateChildItem(selected.item);
            }
            else {
                UpdateItem();
        }
    }

    public void AddItem(ItemHandle fullItem) {
        if (fullItem.item != null)
        {
            items.Add(fullItem.item);
            fullItem.item = null;
            //save inventory
            dataManager.inventory = items;
            UpdateItem();
        }
    }

    public void PutItem(ItemHandle emptyItem) {
        if (emptyItem.PutItem(selected.item)) {
            selected = null;
        }
    }

    public void InitializeInventoryList() {
        items = dataManager.inventory;
        UpdateItem();
    }
}
