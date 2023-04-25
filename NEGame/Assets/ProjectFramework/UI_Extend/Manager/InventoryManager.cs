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

        public Dictionary<string, ItemNode> ItemDicFromBag = new Dictionary<string, ItemNode>(); //�汳����Ʒ��Ϣ
        public Dictionary<string, ItemNode> ItemDicFromHouse = new Dictionary<string, ItemNode>(); //��ֿ���Ʒ����Ϣ
        public Dictionary<string, int> ItemNum = new Dictionary<string, int>(); //����Ʒ����

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
        /// �򱳰���������壬Ĭ��Ϊ1��
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
                //������ز���
                ItemDicFromBag.Remove(item.Name);
                //�ֿ���ز���
                ItemDicFromHouse.Add(item.Name, item);
                
            }
            else if (type == E_TransferType.FromHouseToBag)
            {
                //������ز���
                ItemDicFromBag.Add(item.Name, item);
                
                //�ֿ���ز���
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