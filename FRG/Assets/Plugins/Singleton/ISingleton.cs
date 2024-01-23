/************************************************************
* FileName: ISingleton.cs
* Author: 万剑飞
* Version : 1.1
* Date: 2020.09.27 17:42:08
* Description: 单例接口，Singleton类继承该接口
* ======================================
* ChangeLog：
* 2022.3.17 v1.1
* 1.修改删除单例的方法名为ReleaseSingleton
************************************************************/

public interface ISingleton
{
    void InitSingleton();
    void ReleaseSingleton();
}