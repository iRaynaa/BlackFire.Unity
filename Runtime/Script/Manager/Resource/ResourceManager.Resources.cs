﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections;
using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class ResourceManager
    {
        private Action m_UpdateResource_Delegate;

        private void Init_Resource()
        {

        }

        private void Update_Resource()
        {
            if (null!= m_UpdateResource_Delegate)
            {
                m_UpdateResource_Delegate.Invoke();
            }
        }

        private void Destroy_Resource()
        {

        }




        public void LoadAsync(AssetInfoBase assetInfo, LoadAssetComplete loadResourceComplete, LoadAssetProgress loadResourceProgress = null, LoadAssetFailure loadResourceFailure = null)
        {
            if ( assetInfo is ResourceAssetInfo )
            {
                LoadResourceAsync(assetInfo as ResourceAssetInfo, loadResourceComplete, loadResourceProgress, loadResourceFailure);
            }
            else if (assetInfo is AssetsBundleAssetInfo)
            {
                LoadAssetsBundleAsync(assetInfo as AssetsBundleAssetInfo, loadResourceComplete, loadResourceProgress, loadResourceFailure);
            }
        }



        private void LoadResourceAsync(ResourceAssetInfo assetInfo,LoadAssetComplete loadAssetComplete,LoadAssetProgress loadAssetProgress = null, LoadAssetFailure loadAssetFailure=null)
        {
            var assetObject = HasAsset(assetInfo.AssetPath);

            if (null == assetObject)
            {
                var rr = null!=assetInfo.AssetType?Base_LoadAsync(assetInfo.AssetPath,assetInfo.AssetType):Base_LoadAsync(assetInfo.AssetPath);
                Action action = () => { if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetInfo.AssetPath, rr.progress));  };
                m_UpdateResource_Delegate += action;
                
#if UNITY_2017_1_OR_NEWER
	            rr.completed += ao =>
                {
                    m_UpdateResource_Delegate -= action;
                    if (null == rr.asset)
                    {
                        if (null != loadAssetFailure)
                        {
                            loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetInfo.AssetPath));
                        }
                    }
                    else
                    {
                        AssetAgency assetAgency = m_AssetObjectLinkList.AddLast(new AssetAgency(assetInfo.AssetPath, rr.asset, assetInfo.ShortdatedAsset)).Value;
                        if (null != loadAssetComplete)
                            loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetInfo.AssetPath,assetAgency));
                    }
                };
#elif UNITY_5
                StartCoroutine(LoadResourceAsyncYield(action,rr,assetInfo,loadAssetComplete,loadAssetProgress,loadAssetFailure));
#endif
            }
            else
            {
                if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetInfo.AssetPath,1f));
                if (null != loadAssetComplete) loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetObject.AssetPath,assetObject));

            }
        }
        
#if UNITY_5
        
        private IEnumerator LoadResourceAsyncYield(Action action,ResourceRequest rr,ResourceAssetInfo assetInfo,LoadAssetComplete loadAssetComplete,LoadAssetProgress loadAssetProgress = null, LoadAssetFailure loadAssetFailure=null)
        {
            yield return rr;
            
            m_UpdateResource_Delegate -= action;
            if (null == rr.asset)
            {
                if (null != loadAssetFailure)
                {
                    loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetInfo.AssetPath));
                }
            }
            else
            {
                AssetAgency assetAgency = m_AssetObjectLinkList.AddLast(new AssetAgency(assetInfo.AssetPath, rr.asset, assetInfo.ShortdatedAsset)).Value;
                if (null != loadAssetComplete)
                    loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetInfo.AssetPath,assetAgency));
            }
            
        }

#endif

    }
}
