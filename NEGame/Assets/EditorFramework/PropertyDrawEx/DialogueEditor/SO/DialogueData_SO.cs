using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.EditorFramework
{
    /// <summary>
    /// �Ի��Ŀ��ӻ�����SO
    /// </summary>
    [CreateAssetMenu(fileName = "Dialogue Data", menuName = "Dialogue/Create Dialogue")]
    public class DialogueData_SO : ScriptableObject
    {
        public List<DialogueNode> Nodes;
    }

    /// <summary>
    /// �Ի�����ö��
    /// </summary>
    public enum DialogueNodeType
    {
        Text, //���ı�
        TextWithAvatar, //�ı���ͷ��
        Option, //��ѡ��
        CustomEvent
    }

    /// <summary>
    /// �Ի��ڵ�
    /// </summary>
    [Serializable]
    public class DialogueNode
    {
        public int ID; //�Ի����
        public DialogueNodeType Type; //�Ի�����
        public Sprite Avatar; //�Ի�ͷ��
        public string Info; //�Ի�����
        public List<DialogueOption> Options; //ѡ��
        public List<DialogueEvent> Events; //�Ի���Ļص�
    }

    [Serializable]
    public class DialogueOption
    {
        public string OptionInfo; //ѡ�������
        public DialogueData_SO NextSO; //��һ���Ի�(�����ָ����)
        public int NextPos; //��һ���Ի��ڵ�ı��
    }

    [Serializable]
    public class DialogueEvent
    {
        public string EventName;
        public string Value;
    }
}