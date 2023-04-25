using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Shawn.ProjectFramework
{

    [CreateAssetMenu(fileName = "Card_SO", menuName = "SO/Create Card")]
    public class CardData_SO : ScriptableObject
    {
        public List<CardNode> Nodes;
    }

    public enum E_Card_Type
    {
        Environment,
        Collection,
        Event
    }

    [Serializable]
    public class CardNode
    {
        public int ID;
        public E_Card_Type Type;
        public string Name;
        public string Describtion;
        public UnityAction Effect;
        public List<Options> NextList;
        public List<int> SubCardID;
    }

    [Serializable]
    public class Options
    {
        public string Text;
        public int TargetID;
    }

    
    public class EidtorCustom
    {
        [MenuItem("CONTEXT/CardData_SO/–Ú¡–ªØŒª÷√±‡∫≈")]
        static void SerializeID4()
        {
            System.Object tempObj = EditorUtility.InstanceIDToObject(Selection.activeInstanceID);
            CardData_SO select = (CardData_SO)tempObj;
            for (int id = 0; id < select.Nodes.Count; id++)
            {
                select.Nodes[id].ID = id;
            }
        }
    }
}