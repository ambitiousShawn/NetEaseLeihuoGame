using Shawn.EditorFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.ProjectFramework
{

    public class InventoryManager : IBaseManager
    {
        private const string INVENTORY_PATH = "SO/Inventory_SO";
        public static InventoryManager Instance;

        public Dictionary<string, ItemNode> ItemDicFromBag = new Dictionary<string, ItemNode>(); //存背包物品信息
        public Dictionary<string, ItemNode> ItemDicFromHouse = new Dictionary<string, ItemNode>(); //存仓库物品的信息
        public Dictionary<string, int> ItemNum = new Dictionary<string, int>(); //存物品数量

        public List<ItemNode> itemList;

        private UGUI_MainUIPanel BagPanel;
        private UGUI_WarehousePanel HousePanel;

        public void Init()
        {
            Instance = this;
            itemList = Resources.Load<InventoryData_SO>(INVENTORY_PATH).Nodes;
        }

        public void Tick()
        {
            if (BagPanel == null) BagPanel = PanelManager.Instance.GetPanelByName("UGUI_MainUIPanel") as UGUI_MainUIPanel;
            if (HousePanel == null) HousePanel = PanelManager.Instance.GetPanelByName("UGUI_WarehousePanel") as UGUI_WarehousePanel;

            //Test
            if (Input.GetKeyDown(KeyCode.R))
            {
                AddItemToBag(0, 2);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                AddItemToBag(1, 3);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                AddItemToBag(2, 5);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                ConsumeItem("蓝水晶");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                PanelManager.Instance.ShowPanel<UGUI_WarehousePanel>("UGUI_WarehousePanel");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                TransferItem(1, E_TransferType.FromBagToHouse);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                TransferItem(1, E_TransferType.FromHouseToBag);
            }
            
        }

        /// <summary>
        /// 向背包中添加物体，默认为1个
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        public void AddItemToBag(int id, int num = 1)
        {
            if (BagPanel == null) return;

            ItemNode item = itemList[id];

            if (!ItemDicFromBag.ContainsKey(item.Name))
            {
                ItemDicFromBag.Add(item.Name, item);
                ItemNum.Add(item.Name, num);
            }
            else
            {
                ItemNum[item.Name] += num;
            }
            BagPanel.UpdateInventoryItem();
        }

        public enum E_TransferType
        {
            FromBagToHouse,
            FromHouseToBag
        }

        public void TransferItem (int id, E_TransferType type)
        {
            if (BagPanel == null || HousePanel == null) return;

            ItemNode item = itemList[id];
            if (type == E_TransferType.FromBagToHouse)
            {
                //背包相关操作
                ItemDicFromBag.Remove(item.Name);
                BagPanel.UpdateInventoryItem();
                //仓库相关操作
                ItemDicFromHouse.Add(item.Name, item);
                HousePanel.UpdateHouseItem();
            }
            else if (type == E_TransferType.FromHouseToBag)
            {
                //背包相关操作
                ItemDicFromBag.Add(item.Name, item);
                BagPanel.UpdateInventoryItem();
                //仓库相关操作
                ItemDicFromHouse.Remove(item.Name);
                HousePanel.UpdateHouseItem();
            }
        }

        public void ConsumeItem(string name, int num = 1)
        {
            if (BagPanel == null) return;

            if (ItemNum.ContainsKey(name))
            {
                ItemNum[name] -= num;
                if (ItemNum[name] <= 0)
                {
                    ItemDicFromBag.Remove(name);
                    ItemNum.Remove(name);
                }
                BagPanel.UpdateInventoryItem();
            }
        }
    }

}