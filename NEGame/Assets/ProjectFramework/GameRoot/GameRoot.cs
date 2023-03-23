using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.ProjectFramework
{

    public class GameRoot : MonoBehaviour
    {
        List<IBaseManager> managers = new List<IBaseManager>();

        void Awake()
        {
            managers.Add(new PanelManager());
            managers.Add(new DialogueManager());
            managers.Add(new BuffManager());
            managers.Add(new InventoryManager());
            managers.Add(new TipManager());

            for (int i = 0;i < managers.Count;i++)
            {
                managers[i]?.Init();
            }
        }
        /// <summary>
        /// 仅有TipPanel存在Start方法。
        /// </summary>
        void Start()
        {
            (managers[4] as TipManager).Start();
        }

        void Update()
        {
            for (int i = 0;i < managers.Count; i++)
            {
                managers[i]?.Tick();
            }
        }
    }
}