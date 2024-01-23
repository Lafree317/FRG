/************************************************************
* FileName: MonoSingleton.cs
* Author: 万剑飞
* Version : 1.6
* Date: 2019.08.02 09:27:27
* Description: MonoBehaviour的单例模式，如果未初始化，则全局查找，若未找到，则创建新物体并挂载单例脚本
* ======================================
* ChangeLog：
* 2022.11.19 v1.6
* 1.单例获取中添加lock锁线程
* 
* 2022.3.17 v1.5
* 1.修改删除单例的方法名为ReleaseSingleton
* 
* 2021.10.12 v1.4
* 1.修改Awake和OnDestroy为protected virtual，提供子类重写
* 
* 2021.6.15 v1.3
* 1.在OnDestory中调用ResetSingleton方法，注销
* 
* 2020.9.27 v1.2
* 1.继承接口ISingleton，用于统一管理（泛型类无法存放在列表，因此通过接口来统一管理）
* 2.Init和Reset方法都改为继承接口方法，Init时将对象注册到管理类中
* 
* 2020.7.17 v1.1
* 1.修改重置方法名
* 
************************************************************/

using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour, ISingleton where T : Component
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
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject();
                        instance = go.AddComponent<T>();
                        go.name = typeof(T).ToString();
                    }
                }

                return instance;
            }
        }
    }

    protected virtual void Awake()
    {
        InitSingleton();
    }

    protected virtual void OnDestroy()
    {
        ReleaseSingleton();
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
