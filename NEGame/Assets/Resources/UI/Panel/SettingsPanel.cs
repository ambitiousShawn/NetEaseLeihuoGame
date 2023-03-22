using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shawn.ProjectFramework;
using UnityEngine.UI;

public class SettingsPanel : BasePanel
{
    private Slider mainVolume;
    private Slider musicVolume;
    private Slider soundVolume;
    private Button quitBtn;

    public override void Show()
    {
        base.Show();
        mainVolume = GetControl<Slider>("MainVolume");
        musicVolume = GetControl<Slider>("MusicVolume");
        soundVolume = GetControl<Slider>("SoundVolume");
        quitBtn = GetControl<Button>("QuitBtn");

        quitBtn.onClick.AddListener(() =>
        {
            PanelManager.Instance.HidePanel("SettingsPanel");
            PanelManager.Instance.ShowPanel<BeginPanel>("BeginPanel");
        });

        mainVolume.onValueChanged.AddListener((value) =>
        {
            //���ȫ�ֱ���ģ��������ı�ӿ��߼�
            Debug.Log(value);
        });

        musicVolume.onValueChanged.AddListener((value) =>
        {
            //���ȫ�ֱ���ģ��������ı�ӿ��߼�
        });

        soundVolume.onValueChanged.AddListener((value) =>
        {
            //���ȫ�ֱ���ģ��������ı�ӿ��߼�
        });
    }
}
