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

        public Dictionary<string, ItemNode> ItemDic = new Dictionary<string, ItemNode>(); //����Ʒ��Ϣ
        public Dictionary<string, int> ItemNum = new Dictionary<string, int>(); //����Ʒ����
        private List<ItemNode> itemList;

        private UGUI_MainUIPanel panel;

        public void Init()
        {
            Instance = this;
            itemList = Resources.Load<InventoryData_SO>(INVENTORY_PATH).Nodes;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AddItem(0, 2);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                AddItem(1, 3);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                AddItem(2, 5);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                ConsumeItem("��ˮ��");
            }
        }

        /// <summary>
        /// �򱳰���������壬Ĭ��Ϊ1��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        public void AddItem(int id, int num = 1)
        {
            ItemNode item = itemList[id];
            if (panel == null) panel = PanelManager.Instance.GetPanelByName("UGUI_MainUIPanel") as UGUI_MainUIPanel;

            if (!ItemDic.ContainsKey(item.Name))
            {
                ItemDic.Add(item.Name, item);
                ItemNum.Add(item.Name, num);
            }
            else
            {
                ItemNum[item.Name] += num;
            }
            panel.UpdateInventoryItem();
        }

        public void ConsumeItem(string name, int num = 1)
        {
            if (ItemNum.ContainsKey(name))
            {
                ItemNum[name] -= num;
                if (ItemNum[name] <= 0)
                {
                    ItemDic.Remove(name);
                    ItemNum.Remove(name);
                }
                panel.UpdateInventoryItem();
            }
        }
    }

}