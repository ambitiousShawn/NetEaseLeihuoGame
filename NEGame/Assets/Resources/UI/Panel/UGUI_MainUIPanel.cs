using Shawn.ProjectFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Shawn.ProjectFramework
{

    public class UGUI_MainUIPanel : BasePanel
    {
        private const string BUFF_PATH = "UI/Element/Buff";
        private const string ITEM_PATH = "UI/Element/Item";

        private Scrollbar healthBar;
        private Scrollbar skillBar;
        private Button notes;
        private Transform buffFrame;
        private Transform itemFrame;

        public override void Show()
        {
            base.Show();

            healthBar = GetControl<Scrollbar>("HealthBar");
            skillBar = GetControl<Scrollbar>("SkillBar");
            notes = GetControl<Button>("Notes");
            buffFrame = transform.Find("LeftTop/BuffFrame");
            itemFrame = transform.Find("Bottom/Bag/Grids");

            notes.onClick.AddListener(() =>
            {
                TipManager.Instance.ShowRandomTip();
            });
        }

        /// <summary>
        /// 更新血条
        /// </summary>
        /// <param name="val">将血条更新至多少</param>
        public void UpdateHealthBar(float val)
        {
            healthBar.size = val / 100.00f; //TODO:将100换成总血量
        }

        public void UpdateSkillBar(float val)
        {
            skillBar.size = val / 100.00f; //TODO:将100换成总技能值
        }

        public void UpdateBuffFrame()
        {
            GameObject buff;
            for (int i = 0; i < buffFrame.childCount; i++)
            {
                Destroy(buffFrame.GetChild(i).gameObject);
            }

            foreach (string name in BuffManager.Instance.buffDic.Keys)
            {
                buff = ResourcesManager.Instance.Load<GameObject>(BUFF_PATH);
                buff.transform.SetParent(buffFrame);
                buff.transform.localScale = Vector3.one;
                //TODO：修改buff的Image组件的贴图
            }
        }

        public void UpdateInventoryItem()
        {
            GameObject item;
            for (int i = 0; i < itemFrame.childCount; i++)
            {
                Destroy(itemFrame.GetChild(i).gameObject);
            }

            foreach (string name in InventoryManager.Instance.ItemDic.Keys)
            {
                item = ResourcesManager.Instance.Load<GameObject>(ITEM_PATH);
                item.transform.SetParent(itemFrame);
                item.transform.localScale = Vector3.one;
                item.GetComponentInChildren<Text>().text = InventoryManager.Instance.ItemNum[name].ToString();
                //TODO:修改Item的Image贴图组件
            }
        }
    }

}