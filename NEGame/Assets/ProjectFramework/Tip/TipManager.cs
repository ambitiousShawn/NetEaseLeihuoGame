using Shawn.EditorFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.ProjectFramework
{

    public class TipManager : IBaseManager
    {
        private const string TIP_PATH = "SO/Tip_SO";
        public static TipManager Instance;

        private List<TipNode> tipList;
        private TipPanel panel;
        private GameObject tipObj;

        public void Init()
        {
            Instance = this;

            tipList = Resources.Load<TipData_SO>(TIP_PATH).Nodes;
            PanelManager.Instance.ShowPanel<TipPanel>("TipPanel");
        }

        public void Start()
        {
            panel = PanelManager.Instance.GetPanelByName("TipPanel") as TipPanel;
            tipObj = panel.gameObject;
            tipObj.SetActive(false);
        }

        public void Tick()
        {
            if (tipObj.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            {
                HideTip();
            }
        }

        public void ShowRandomTip()
        {
            tipObj.SetActive(true);
            int rand = Random.Range(0, tipList.Count);
            panel.UpdateQAndA(tipList[rand].Q, tipList[rand].A);
        }

        public void HideTip()
        {
            tipObj.SetActive(false);
        }
    }
}