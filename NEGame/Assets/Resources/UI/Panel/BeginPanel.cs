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
            //TODO:����л���������Ϸ�Ľӿ��߼�
        });

        loadBtn.onClick.AddListener(() =>
        {
            //TODO:���������Ϸ��������Ϸ�Ľӿ��߼�
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
