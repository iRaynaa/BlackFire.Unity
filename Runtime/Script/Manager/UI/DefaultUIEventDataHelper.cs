﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFire.Unity
{
    public sealed class DefaultUIEventDataHelper : GraphicRaycaster , IUIEventDataHelper
    {

        private PointerEventData m_PointerEventData = null;
        private List<RaycastResult> m_RaycastResultList = null;
        public PointerEventData PointerEventData
        {
            get
            {
                return m_PointerEventData;
            }
        }
        public List<RaycastResult> RaycastResultList
        {
            get
            {
                return m_RaycastResultList;
            }
        }



        public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
        {
            m_PointerEventData = eventData;
            m_RaycastResultList = resultAppendList;
            base.Raycast(eventData, resultAppendList);
        }

    }

}
