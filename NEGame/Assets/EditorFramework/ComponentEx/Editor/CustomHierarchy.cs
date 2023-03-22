using UnityEditor;
using UnityEngine;

namespace Shawn.EditorFramework
{

    /// <summary>
    /// 对Hierachy的扩展工具。
    /// </summary>
    public class CustomHierarchy
    {
        [MenuItem("CONTEXT/DialogueData_SO/序列化位置编号")]
        static void SerializePos()
        {
            Object tempObj = EditorUtility.InstanceIDToObject(Selection.activeInstanceID);
            DialogueData_SO select = (DialogueData_SO)tempObj;
            for (int pos = 0; pos < select.Nodes.Count; pos++)
            {
                select.Nodes[pos].Pos = pos;
            }
        }

        [MenuItem("CONTEXT/BuffData_SO/序列化位置编号")]
        static void SerializeID()
        {
            Object tempObj = EditorUtility.InstanceIDToObject(Selection.activeInstanceID);
            BuffData_SO select = (BuffData_SO)tempObj;
            for (int id = 0; id < select.Nodes.Count; id++)
            {
                select.Nodes[id].ID = id;
            }
        }
    }
}