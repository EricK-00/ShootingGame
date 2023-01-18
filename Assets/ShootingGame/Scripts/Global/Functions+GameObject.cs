using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class Functions
{
    //! Ư�� ���ӿ�����Ʈ�� �ڽ��� Ž���ؼ� ã�� �޼���
    //private static GameObject GetChildGameObject(this GameObject parentGO, string childName)
    //{
    //    for (int i = 0; i < parentGO.transform.childCount; i++)
    //    {
    //        if (parentGO.transform.GetChild(i).name.Equals(childName))
    //        {
    //            return parentGO.transform.GetChild(i).gameObject;
    //        }
    //    }

    //    return default;
    //}

    //! Ư�� ���ӿ�����Ʈ�� �ڽĵ��� Ž���ؼ� ã�� �޼���
    public static GameObject FindChildGameObject(this GameObject parentGO, string childName)
    {
        GameObject searchTarget;

        for (int i = 0; i < parentGO.transform.childCount; i++)
        {
            searchTarget = parentGO.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(childName))
            {
                return searchTarget;
            }
            else
            {
                GameObject go = FindChildGameObject(searchTarget, childName);
                if (go != null)
                    return go;
            }
        }

        return null;
    }

    //! ��Ʈ ���ӿ�����Ʈ�� Ž���ؼ� ã�� �޼���
    public static GameObject GetRootGameObject(string goName)
    {
        Scene activeScene = GetActiveScene();
        GameObject[] rootGOs = activeScene.GetRootGameObjects();

        foreach (GameObject go in rootGOs)
        {
            if (go.name.Equals(goName))
            {
                return go;
            }
        }

        return default;
    }

    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }
}
