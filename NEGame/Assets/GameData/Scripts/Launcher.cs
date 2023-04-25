using Shawn.GameLogic;
using Shawn.ProjectFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private readonly List<IBaseManager> managers = new List<IBaseManager>();

    private void Awake()
    {
        managers.Add(new PanelManager());
        managers.Add(new CardProcessManager());
        managers.Add(new Interaction());

        for (int i = 0; i < managers.Count; i++)
        {
            managers[i]?.Init();
        }
    }

    void Start()
    {
        PanelManager.Instance.ShowPanel<UGUI_CardPanel>("UGUI_CardPanel");
    }

    void Update()
    {
        for (int i = 0;i < managers.Count;i++)
        {
            managers[i]?.Tick();
        }
    }
}
