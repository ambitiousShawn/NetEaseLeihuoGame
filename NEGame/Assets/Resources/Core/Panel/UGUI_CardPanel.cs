using Shawn.GameLogic;
using Shawn.ProjectFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUI_CardPanel : BasePanel
{
    private static string Res_Path = string.Empty;

    public Text Name;
    public Text Describtion;
    public Image CardTex;
    public Button[] Options;

    int pos;

    public override void Show()
    {
        DataManager.Init();
        //初始化卡牌面板
        pos = CardProcessManager.Instance.pos;
        InitPanel(DataManager.cardList[pos]);
    }

    private void InitPanel(CardNode card)
    {
        Name.text = card.Name;
        Describtion.text = card.Describtion;
        //CardTex.sprite = Resources.Load<Sprite>(Res_Path + Name); //贴图路径以序号命名

        int optionNum = card.NextList.Count;
        int i = 0;
        for (i = 0; i < optionNum; i++)
        {
            Button Option = Options[i];
            Option.gameObject.SetActive(true);
            Option.GetComponentInChildren<Text>().text = card.NextList[i].Text;
            int nextPos = card.NextList[i].TargetID;
            Option.onClick.AddListener(() =>
            {
                CardProcessManager.Instance.JumpToAllPosition(nextPos);
                pos = nextPos;
                InitPanel(DataManager.cardList[pos]) ;
            });
            
        }
        for (int j = i; j < 3; j++)
        {
            Button Option = Options[j];
            Option.gameObject.SetActive(false);
        }
    }

    public override void Hide()
    {
        base.Hide();
    }
}
