/************************************************************
* FileName: Singleton.cs
* Author: 万剑飞
* Version : 1.5
* Date: 2019.08.02 09:23:45
* Description: 单例模式基类
* ======================================
* ChangeLog：
* 2022.11.19 v1.5
* 1.单例获取中添加lock锁线程
* 
* 2022.3.17 v1.4
* 1.修改删除单例的方法名为ReleaseSingleton
* 
* 2021.9.13 v1.3
* 1.修改注册方法名字
* 2.重置时添加取消注册
* 
* 2020.9.27 v1.2
* 1.继承接口ISingleton，用于统一管理（泛型类无法存放在列表，因此通过接口来统一管理）
* 2.Init和Reset方法都改为继承接口方法，Init时将对象注册到管理类中
*
* 2020.7.17 v1.1
* 1.修改重置方法名
************************************************************/

public class Singleton<T> : ISingleton where T : class, new()
{
    private static object obj = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            lock (obj)
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }
    }

    public Singleton()
    {
        InitSingleton();
    }

    public virtual void InitSingleton()
    {
        SingletonManager.Register(this);
    }

    public virtual void ReleaseSingleton()
    {
        instance = null;
        SingletonManager.Unregister(this);
    }
}