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
    public static partial class Utility
    {

        public static class Screen
        {
            /// <summary>
            /// 屏幕截屏。(注意:请在WaitForEndOfFrame时机调用,也就是一帧结束的时候调用。)
            /// </summary>
            /// <param name="captureRect"></param>
            /// <returns></returns>
            public static Texture2D ScreenCapture(Rect captureRect,TextureFormat textureFormat)
            {
                Texture2D photo = new Texture2D((int)captureRect.width,(int)captureRect.height,textureFormat,false);
                photo.ReadPixels(captureRect, 0, 0, false);
                photo.Apply();
                return photo;
            }
        }
        
    }
}
