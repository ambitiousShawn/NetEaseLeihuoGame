using Shawn.GameLogic;
using Shawn.ProjectFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private void Awake()
    {
        new PanelManager().Init();
        new CardProcessManager().Init();
    }

    void Start()
    {
        PanelManager.Instance.ShowPanel<UGUI_CardPanel>("UGUI_CardPanel");
    }

    void Update()
    {
        
    }
}
