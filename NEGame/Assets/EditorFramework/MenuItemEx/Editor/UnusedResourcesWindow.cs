using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GUILayout;

namespace Shawn.EditorFramework
{
    
    public class UnusedResourcesWindow : EditorWindow
    {
        Vector2 scroll = default;

        [MenuItem("Assets/����/01.��ѯδ������Դ")]
        static void CheckUnusedResource()
        {
            UnusedResourcesWindow window = CreateInstance<UnusedResourcesWindow>();
            window.Show();
        }

        List<DeleteAssetData> deleteAssetDatas = new List<DeleteAssetData>()
        {
            new DeleteAssetData(),
            new DeleteAssetData()
        };

        void OnGUI()
        {
            using (var horizontal = new EditorGUILayout.HorizontalScope("box"))
            {
                EditorGUILayout.LabelField("������Դδʹ�� ��ɾ��");
            }

            using (ScrollViewScope scrollScope = new ScrollViewScope(scroll))
            {
                scroll = scrollScope.scrollPosition;
                foreach (DeleteAssetData data in deleteAssetDatas)
                {
                    if (string.IsNullOrEmpty(data.filePath)) continue;
                    {
                        using (var horizontal = new EditorGUILayout.HorizontalScope())
                        {
                            Texture icon = AssetDatabase.GetCachedIcon(data.filePath);
                            Label(icon, Width(20), Height(20));
                            Label(data.filePath);
                            if (Button("ѡ��", Width(40),Height(20)))
                            {
                                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(data.filePath);
                            }
                            if (Button("�Ƴ�", Width(40), Height(20)))
                            {
                                AssetDatabase.DeleteAsset(data.filePath);
                            }
                        }
                    }
                }
            }
        }
    }
}