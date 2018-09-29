﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using BlackFire;

/// <summary>
/// IoC注册接口。
/// </summary>
public interface IIoCRegister
{
    /// <summary>
    /// 注册事件。
    /// </summary>
    /// <param name="ioc">IoC实例。</param>
    void OnRegister(ISparrowIoC ioc);

}