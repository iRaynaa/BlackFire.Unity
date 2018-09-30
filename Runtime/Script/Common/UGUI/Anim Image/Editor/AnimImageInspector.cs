﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
	[CustomEditor(typeof(AnimImage), false)]
	public class AnimImageInspector : GraphicEditor
	{
		private SerializedProperty m_SP_Rows;
		private SerializedProperty m_SP_Cols;
		private SerializedProperty m_SP_Sprite;
		private SerializedProperty m_SP_Fps;
		private SerializedProperty m_SP_Skip;
		private SerializedProperty m_SP_RaycastTarget;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_SP_Rows = serializedObject.FindProperty("m_Rows");
			m_SP_Cols = serializedObject.FindProperty("m_Cols");
			m_SP_Sprite = serializedObject.FindProperty("m_Sprite");
			m_SP_Fps = serializedObject.FindProperty("m_Fps");
			m_SP_Skip = serializedObject.FindProperty("m_Skip");
			m_SP_RaycastTarget = serializedObject.FindProperty("m_RaycastTarget");
		}

		public override void OnInspectorGUI()
		{
			AnimImage t = (AnimImage) target;
			
			EditorGUILayout.Space();

			BlackFireEditorGUI.BoxVerticalLayout(()=>
			{
				EditorGUILayout.PropertyField(m_SP_Sprite);

				if (null != t.Sprite)
				{
					EditorGUILayout.PropertyField(m_SP_Rows);
					EditorGUILayout.PropertyField(m_SP_Cols);
					EditorGUILayout.PropertyField(m_SP_Skip);
					EditorGUILayout.PropertyField(m_SP_Fps);
				}
				
				EditorGUILayout.PropertyField(m_SP_RaycastTarget);
				
				if (null != t.Sprite)
				{
						BlackFireEditorGUI.HorizontalLayout(() =>
						{
							GUILayout.Space(EditorGUIUtility.labelWidth);
							if (GUILayout.Button("Set Native Size",EditorStyles.miniButton))
							{
								t.SetNativeSize();
								EditorUtility.SetDirty(t);
							}
						});
				}

				if (null == t.Sprite)
				{
					m_SP_Rows.intValue = 0;
					m_SP_Cols.intValue = 0;
					m_SP_Skip.intValue = 0;
					m_SP_Fps.floatValue = 60f;
				}
				
			});
			

			
			serializedObject.ApplyModifiedProperties();
		}
		
		
		
	}
}