﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    
    /// <summary>
    /// BlackFireFramework主要程序入口类。
    /// </summary>
    [GameObjectIcon("BlackFire")]
    public sealed partial class App : MonoBehaviour
    {
        #region LifeCircle
    
        /// <summary>
        /// 框架所有者。
        /// </summary>
        private static readonly object s_Unity = new object();
    
        /// <summary>
        /// BlackFire行为类唯一实例。
        /// </summary>
        private static App s_Instance = null;
    
        /// <summary>
        /// 放到DontDestroyOnLoad场景。
        /// </summary>
        [SerializeField] private bool m_DontDestroy=true;
    
        /// <summary>
        /// 场景加载之前事件。
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoad()
        {
            Log.SetLogCallback(LogCallback);
            BlackFire.Event.SetGetEventHandlersCallback(GetEventHandlersCallback);
            Framework.Born(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);
        }
    
        private void Awake()
        {
            if(m_DontDestroy)
                DontDestroyOnLoad();            
        }
    
        /// <summary>
        /// 初始化（只执行一次）。
        /// </summary>
        private void Init()
        {
            SetIterator(this);
            StartIoC();
            StartAssemblyManager(this);
            StartModuleManager(this);
            StartUnityManager(this);
        }
        
        
        /// <summary>
        /// 轮询事件。
        /// </summary>
        private void Update()
        {
            Framework.Act(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);
        }
    
        /// <summary>
        /// 被销毁事件。
        /// </summary>
        private void OnDestroy()
        {
            if (!this.Equals(s_Instance)) return;
            
            ShutdownAssemblyManager();
            ShutdownUnityManager(this);
    
            Framework.Die(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);
    
            if (this.Equals(s_Instance))
            {
                s_Instance = null;
            }
        }
    
    
    
        /// <summary>
        /// 过场景不销毁。
        /// </summary>
        private void DontDestroyOnLoad()
        {
            if (null == s_Instance)
            {
                s_Instance = this;
                DontDestroyOnLoad(gameObject);
                Init();
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
    
    
        #endregion
    }

}



