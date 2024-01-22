using System;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
	private static Dictionary<EventType, Delegate> m_EventTable = new Dictionary<EventType, Delegate>();

	private static void ListenerAdding(EventType eventType, Delegate callBack)
	{
		if (!m_EventTable.ContainsKey(eventType))
		{
			m_EventTable.Add(eventType, null);
		}
		Delegate d = m_EventTable[eventType];
		if (d != null && d.GetType() != callBack.GetType())
		{
			Debug.Log(string.Format("尝试为事件{0}添加不同类型的委托，当前事件" +
				"对应的委托是{1},要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
		}
	}
	private static bool ListenerRemoving(EventType eventType, Delegate callBack)
	{
		if (m_EventTable.ContainsKey(eventType))
		{
			Delegate d = m_EventTable[eventType];
			if (d == null)
			{
				Debug.Log(string.Format("移除监听错误：事件{0}没有对应的委托", eventType));
				return false;
			}
			else if (d.GetType() != callBack.GetType())
			{
				Debug.Log(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，" +
					"当前委托类型为{1},要移除的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
				return false;
			}
		}
		else
		{
			Debug.Log(string.Format("移除监听错误，没有事件{0}", eventType));
				return false;
		}
		return true ;

	}
	private static void ListenerRemoved(EventType eventType)
	{
		if (m_EventTable[eventType] == null)
		{
			m_EventTable.Remove(eventType);
		}
	}
	/// no parameters
	public static void AddListener(EventType eventType, CallBack callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack)m_EventTable[eventType] + callBack;
	}

	/// single parameters
	public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] + callBack;
	}

	/// two parameters
	public static void AddListener<T, X>(EventType eventType, CallBack<T, X> callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] + callBack;
	}

	/// three parameters
	public static void AddListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] + callBack;
	}

	/// four parameters
	public static void AddListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] + callBack;
	}

	/// five parameters
	public static void AddListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
	{
		ListenerAdding(eventType, callBack);
		m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] + callBack;
	}

	/// no parameters
	public static void RemoveListener(EventType eventType, CallBack callBack)
	{
		if (false == m_EventTable.ContainsKey(eventType))
		{
			Debug.Log("移除监听不包含Key  eventType");
			return;
		}
		if ( ListenerRemoving(eventType , callBack) == false ) return;

		m_EventTable[eventType] = (CallBack) m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// single parameters
	public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
	{
		if (false == m_EventTable.ContainsKey(eventType))
		{
			Debug.Log("移除监听不包含Key  eventType");
			return;
		}
		if ( ListenerRemoving(eventType , callBack) == false ) return;
		m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// two parameters
	public static void RemoveListener<T, X>(EventType eventType, CallBack<T, X> callBack)
	{
		if ( ListenerRemoving(eventType , callBack) == false ) return;
		m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// three parameters
	public static void RemoveListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
	{
		if ( ListenerRemoving(eventType , callBack) == false ) return;
		m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// four parameters
	public static void RemoveListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
	{
		if ( ListenerRemoving(eventType , callBack) == false ) return;
		m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// five parameters
	public static void RemoveListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
	{
		if ( ListenerRemoving(eventType , callBack) == false ) return;
		m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] - callBack;
		ListenerRemoved(eventType);
	}

	/// no parameters
	public static void Broadcast(EventType eventType)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack callBack = d as CallBack;
			if (callBack != null)
			{
				callBack();
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}

	/// single parameters
	public static void Broadcast<T>(EventType eventType, T arg)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack<T> callBack = d as CallBack<T>;
			if (callBack != null)
			{
				callBack(arg);
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}

	/// two parameters
	public static void Broadcast<T, X>(EventType eventType, T arg, X arg1)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack<T, X> callBack = d as CallBack<T, X>;
			if (callBack != null)
			{
				callBack(arg, arg1);
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}

	/// three parameters
	public static void Broadcast<T, X, Y>(EventType eventType, T arg, X arg1, Y arg2)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
			if (callBack != null)
			{
				callBack(arg, arg1, arg2);
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}

	/// four parameters
	public static void Broadcast<T, X, Y, Z>(EventType eventType, T arg, X arg1, Y arg2, Z arg3)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
			if (callBack != null)
			{
				callBack(arg, arg1, arg2, arg3);
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}

	/// five parameters
	public static void Broadcast<T, X, Y, Z, W>(EventType eventType, T arg, X arg1, Y arg2, Z arg3, W arg4)
	{
		Delegate d;
		if (m_EventTable.TryGetValue(eventType, out d))
		{
			CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
			if (callBack != null)
			{
				callBack(arg, arg1, arg2, arg3, arg4);
			}
			else
			{
				// throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", eventType));
			}
		}
	}
}