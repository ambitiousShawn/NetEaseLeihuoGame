using Shawn.ProjectFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.GameLogic
{

    public class DataManager
    {
        //资源路径
        private const string CARD_PATH = "SO/Card_SO";

        public static List<CardNode> cardList;

        public static void Init()
        {
            cardList = Resources.Load<CardData_SO>(CARD_PATH).Nodes;
        }
    }

}