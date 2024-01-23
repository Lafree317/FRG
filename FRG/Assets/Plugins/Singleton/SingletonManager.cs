/************************************************************
* FileName: SingletonManager.cs
* Author: 万剑飞
* Version : 1.3
* Date: 2020.09.27 17:09:46
* Description: 单例管理类
* ======================================
* ChangeLog：
* 2022.11.19 v1.3
* 1.修改Reset方法中的循环，原来用Foreach会报错，因为循环体里会改变singletons列表
* 
* 2022.3.17 v1.2
* 1.修改删除单例的方法名为ReleaseSingleton
* 
* 2021.6.15 v1.1
* 1.添加注销单例的Unregister方法
************************************************************/

using System.Collections.Generic;

public static class SingletonManager
{
    private static List<ISingleton> singletons = new List<ISingleton>();//单例列表

    /// <summary>
    /// 注册单例
    /// </summary>
    /// <param name="singleton"></param>
    public static void Register(ISingleton singleton)
    {
        if (!singletons.Contains(singleton))
        {
            singletons.Add(singleton);
        }
    }

    /// <summary>
    /// 注销单例
    /// </summary>
    /// <param name="singleton"></param>
    public static void Unregister(ISingleton singleton)
    {
        if (singletons.Contains(singleton))
        {
            singletons.Remove(singleton);
        }
    }

    /// <summary>
    /// 释放所有单例
    /// </summary>
    public static void ReleaseAll()
    {
        //while (singletons.Count != 0)
        //{
        //    singletons[0].ReleaseSingleton();
        //}
        for (int i = 0; i < singletons.Count; i++)
        {
            singletons[i].ReleaseSingleton();
        }

        singletons.Clear();
    }
}