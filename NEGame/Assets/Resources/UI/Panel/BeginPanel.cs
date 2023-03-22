using Shawn.ProjectFramework;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    private Button startBtn;
    private Button loadBtn;
    private Button settingsBtn;
    private Button quitBtn;

    public override void Show()
    {
        base.Show();

        startBtn = GetControl<Button>("StartBtn");
        loadBtn = GetControl<Button>("LoadBtn");
        settingsBtn = GetControl<Button>("SettingsBtn");
        quitBtn = GetControl<Button>("QuitBtn");

        startBtn.onClick.AddListener(() =>
        {
            //TODO:添加切换场景到游戏的接口逻辑
        });

        loadBtn.onClick.AddListener(() =>
        {
            //TODO:添加载入游戏场景到游戏的接口逻辑
        });

        settingsBtn.onClick.AddListener(() =>
        {
            PanelManager.Instance.ShowPanel<SettingsPanel>("SettingsPanel");
            PanelManager.Instance.HidePanel("BeginPanel");
        });

        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
