using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GUILayout;

namespace Shawn.EditorFramework
{
    
    public class UnusedResourcesWindow : EditorWindow
    {
        AssetCollector collector = new AssetCollector();

        Vector2 scroll = default;

        public const string Check_Folder_Path = "Assets"; //�����Ŀ¼

        [MenuItem("Universal Tools/��Դ/01.��ѯδ������Դ %/", priority = -1)]
        static void CheckUnusedResource()
        {
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            UnusedResourcesWindow window = CreateInstance<UnusedResourcesWindow>();
            window.collector.Collection(new string[] { Check_Folder_Path });
            window.CopyDeleteFileList(window.collector.deleteFileList);
            window.Show();
        }

        

        #region Test
        /*        List<DeleteAssetData> deleteAssetDatas = new List<DeleteAssetData>()
                {
                    new DeleteAssetData(),
                };*/
        #endregion

        List<DeleteAssetData> deleteAssetCollection = new List<DeleteAssetData>();

        void OnGUI()
        {
            using (var horizontal = new EditorGUILayout.HorizontalScope("box"))
            {
                EditorGUILayout.LabelField("������Դδʹ��(����̬������δʹ��,����ʹ��ɾ������)");
            }

            using (ScrollViewScope scrollScope = new ScrollViewScope(scroll))
            {
                scroll = scrollScope.scrollPosition;
                List<DeleteAssetData> tempList = new List<DeleteAssetData>() ;
                
                foreach (DeleteAssetData data in deleteAssetCollection)
                {
                    tempList.Add(data);
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
                                if (EditorUtility.DisplayDialog("", "�Ƿ�ȷ��ɾ�����ļ�", "ȷ��", "ȡ��"))
                                {
                                    tempList.Remove(data);
                                    AssetDatabase.DeleteAsset(data.filePath);
                                }
                            }
                        }
                    }
                    deleteAssetCollection = tempList;
                }
            }
        }
        private void CopyDeleteFileList(IEnumerable<string> deleteFileList)
        {
            deleteAssetCollection.Clear();
            foreach (string asset in deleteFileList)
            {
                string filePath = AssetDatabase.GUIDToAssetPath(asset);

                if (!string.IsNullOrEmpty(filePath))
                {
                    DeleteAssetData tempDelData = new DeleteAssetData();
                    tempDelData.filePath = filePath;
                    deleteAssetCollection.Add(tempDelData);
                }
            }
        }
    }
}