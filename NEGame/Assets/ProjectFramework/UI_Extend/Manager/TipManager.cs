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
        

        public void Init()
        {
            Instance = this;

            tipList = Resources.Load<TipData_SO>(TIP_PATH).Nodes;
        }

        public void Tick()
        {
            
        }

        public void ShowRandomTip()
        {
           
        }

        public void HideTip()
        {
            
            PanelManager.Instance.HidePanel("UGUI_TipPanel");
        }
    }
}