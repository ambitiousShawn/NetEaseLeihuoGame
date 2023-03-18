using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Shawn.EditorFramework
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof (DialogueNode))]
    public class DialogueNodeDrawer : PropertyDrawer
    {
        private const float LINE_HEIGHT = 20;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //base.OnGUI(position, property, label);

            EditorGUI.BeginProperty(position, label, property);
            {
                SerializedProperty id = property.FindPropertyRelative("ID");
                SerializedProperty type = property.FindPropertyRelative("Type");
                SerializedProperty info = property.FindPropertyRelative("Info");
                SerializedProperty avatar = property.FindPropertyRelative("Avatar");
                SerializedProperty options = property.FindPropertyRelative("Options");
                SerializedProperty events = property.FindPropertyRelative("Events");

                GUI.enabled = false;
              
                Rect idPos = position;
                idPos.height = LINE_HEIGHT;
                EditorGUI.PropertyField(idPos, id);
                idPos.y += LINE_HEIGHT;

                GUI.enabled = true;

                Rect typePos = idPos;
                typePos.height = LINE_HEIGHT;
                EditorGUI.PropertyField(typePos, type);
                typePos.y += LINE_HEIGHT;

                if (type.intValue == (int)DialogueNodeType.Text)
                {
                    Rect infoPos = typePos;
                    infoPos.height = LINE_HEIGHT;
                    EditorGUI.PropertyField(infoPos, info);
                    infoPos.y += infoPos.height;
                }
                else if (type.intValue == (int)DialogueNodeType.TextWithAvatar)
                {
                    Rect infoPos = typePos;
                    infoPos.height = LINE_HEIGHT;
                    EditorGUI.PropertyField(infoPos, info);
                    infoPos.y += infoPos.height;

                    Rect avatarPos = infoPos;
                    avatarPos.height = LINE_HEIGHT;
                    EditorGUI.PropertyField(avatarPos, avatar);
                    avatarPos.y += LINE_HEIGHT;
                }
                else if (type.intValue == (int)DialogueNodeType.Option)
                {
                    Rect infoPos = typePos;
                    infoPos.height = LINE_HEIGHT;
                    EditorGUI.PropertyField(infoPos, info);
                    infoPos.y += infoPos.height;

                    Rect optionsPos = infoPos;
                    optionsPos.height = (options.arraySize + 1) * LINE_HEIGHT;
                    EditorGUI.PropertyField(optionsPos, options);
                    optionsPos.y += LINE_HEIGHT;

                     
                }
                else if (type.intValue == (int)DialogueNodeType.CustomEvent)
                {
                    Rect eventsPos = typePos;
                    eventsPos.height = LINE_HEIGHT;
                    EditorGUI.PropertyField(eventsPos, events);
                    eventsPos.y += LINE_HEIGHT;
                }

                /*switch ((DialogueNodeType)type.intValue)
                {
                    case DialogueNodeType.Text:
                        {
                            Rect infoPos = position;
                            infoPos.height = LINE_HEIGHT;
                            EditorGUI.PropertyField(infoPos, info);
                            infoPos.y += infoPos.height;
                            break;
                        }
                    case DialogueNodeType.TextWithAvatar:
                        {
                            Rect avatarPos = position;
                            avatarPos.height = LINE_HEIGHT;
                            EditorGUI.PropertyField(avatarPos, avatar);
                            avatarPos.y += LINE_HEIGHT;

                            Rect infoPos = position;
                            infoPos.height = LINE_HEIGHT;
                            EditorGUI.PropertyField(infoPos, info);
                            infoPos.y += infoPos.height;
                            break;
                        }
                    case DialogueNodeType.Option:
                        {
                            Rect optionsPos = position;
                            optionsPos.height = (options.arraySize + 1) * LINE_HEIGHT ;
                            EditorGUI.PropertyField(optionsPos, options);
                            optionsPos.y += LINE_HEIGHT;
                            break;
                        }
                    case DialogueNodeType.CustomEvent:
                        {
                            Rect eventsPos = position;
                            eventsPos.height = LINE_HEIGHT;
                            EditorGUI.PropertyField(eventsPos, events);
                            eventsPos.y += LINE_HEIGHT;
                            break;
                        }
                }*/
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.Text)
                return 60;
            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.TextWithAvatar)
                return 80;
            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.Option)
                return 40 + property.FindPropertyRelative("Options").CountInProperty() * 20 + 40;
            if (property.FindPropertyRelative("Type").intValue == (int)DialogueNodeType.CustomEvent)
                return 40 + property.FindPropertyRelative("Events").CountInProperty() * 20 + 40;
            return 20;
        }
    }
#endif
}