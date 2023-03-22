using Shawn.ProjectFramework;
using UnityEngine;
using UnityEngine.UI;

public class MainUIPanel : BasePanel
{
    private const string BUFF_PATH = "UI/Element/Buff";

    private Scrollbar healthBar;
    private Scrollbar skillBar;
    private Button notes;
    private Transform buffFrame;

    public override void Show()
    {
        base.Show();

        healthBar = GetControl<Scrollbar>("HealthBar");
        skillBar = GetControl<Scrollbar>("SkillBar");
        notes = GetControl<Button>("Notes");
        buffFrame = transform.Find("LeftTop/BuffFrame");

        notes.onClick.AddListener(() =>
        {
            //TODO:���notes��ʾ�Ĺ����߼�
        });
    }

    /// <summary>
    /// ����Ѫ��
    /// </summary>
    /// <param name="val">��Ѫ������������</param>
    public void UpdateHealthBar(float val)
    {
        healthBar.size = val / 100.00f; //TODO:��100������Ѫ��
    }

    public void UpdateSkillBar(float val)
    {
        skillBar.size = val / 100.00f; //TODO:��100�����ܼ���ֵ
    }

    public void UpdateBuffFrame()
    {
        GameObject buff;
        for (int i = 0;i < buffFrame.childCount; i++)
        {
            Destroy(buffFrame.GetChild(i).gameObject);
        }

        foreach (string name in BuffManager.Instance.buffDic.Keys)
        {
            buff = ResourcesManager.Instance.Load<GameObject>(BUFF_PATH);
            buff.transform.SetParent(buffFrame);
            buff.transform.localScale = Vector3.one;
            //TODO���޸�buff��Image�������ͼ
        }
    }
}
