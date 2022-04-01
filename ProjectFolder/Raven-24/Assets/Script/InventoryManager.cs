using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // global config
    public bool isActive;
    public PlayerMove playerMove;
    public MouseMove mouseMove;
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
    // this is used to instantiate object in 2D list;
    public GameObject itenUIPF;

    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("UpdateItem",1f);
        ShowDetail(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void UpdateItem() {
        List<Item> items = dataManager.inventory;
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
        GameObject newItemUI = Instantiate(itenUIPF, self.transform);
        newItemUI.GetComponent<ItemUI>().self = newItemUI;
        newItemUI.GetComponent<ItemUI>().inventoryManager = self.GetComponent<InventoryManager>();
        newItemUI.GetComponent<ItemUI>().item = i;
        newItemUI.GetComponent<ItemUI>().icon.sprite = i._icon;
    }

    public void ShowDetail(bool state)
    {
        detailWindow.SetActive(state);
        playerMove.isActive = !state;
        mouseMove.isActive = !state;
        if (state)
        {
            string simpleRender = "";
            foreach(string i in selected.GetComponent<ItemUI>().item._info){
                simpleRender += i + "\n\n";
            }
            detailInfo.text = simpleRender;
            detailTitle.text = selected.GetComponent<ItemUI>().item._title;
            detailImage.sprite = selected.GetComponent<ItemUI>().item._icon;
            if (selected.GetComponent<ItemUI>().item._childs.Count > 0)
            {
                UpdateChildItem(selected.GetComponent<ItemUI>().item);
                selected = null;
            }
        }
        else
        {
            UpdateItem();
        }
    }

    public void AddItem(ItemHandle fullItem) {
        if (fullItem.item != null)
        {
            dataManager.inventory.Add(fullItem.PickItem());
            fullItem.item = null;
            UpdateItem();
        }
    }

    public bool PutItem(ItemHandle emptyItem) {
        if (selected != null)
        {
            if (emptyItem.PutItem(selected.GetComponent<ItemUI>().item))
            {
                dataManager.inventory.Remove(selected.GetComponent<ItemUI>().item);
                selected = null;
                UpdateItem();
            }
            return true;
        }
        return false;
    }
    
}
