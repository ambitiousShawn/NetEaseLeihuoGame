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


        public void Init()
        {
            Instance = this;
            itemList = Resources.Load<InventoryData_SO>(INVENTORY_PATH).Nodes;
        }

        public void Tick()
        {            
        }

        /// <summary>
        /// 向背包中添加物体，默认为1个
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        public void AddItemToBag(int id, int num = 1)
        {

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
            
        }

        public enum E_TransferType
        {
            FromBagToHouse,
            FromHouseToBag
        }

        public void TransferItem (int id, E_TransferType type)
        {
            

            ItemNode item = itemList[id];
            if (type == E_TransferType.FromBagToHouse)
            {
                //背包相关操作
                ItemDicFromBag.Remove(item.Name);
                //仓库相关操作
                ItemDicFromHouse.Add(item.Name, item);
                
            }
            else if (type == E_TransferType.FromHouseToBag)
            {
                //背包相关操作
                ItemDicFromBag.Add(item.Name, item);
                
                //仓库相关操作
                ItemDicFromHouse.Remove(item.Name);
            }
        }

        public void ConsumeItem(string name, int num = 1)
        {

            if (ItemNum.ContainsKey(name))
            {
                ItemNum[name] -= num;
                if (ItemNum[name] <= 0)
                {
                    ItemDicFromBag.Remove(name);
                    ItemNum.Remove(name);
                }
            }
        }
    }

}