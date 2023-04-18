using Shawn.ProjectFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shawn.GameLogic
{

    public class CardCoreLogic : MonoBehaviour
    {
        //组件信息
        private Animator anim;
        private Button btn;

        //卡牌数据
        private List<CardNode> cardList;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            btn = GetComponent<Button>();
            DataManager.Init(); //初始化数据
            cardList = DataManager.cardList;

            btn.onClick.AddListener(() =>
            {

            });
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }

}