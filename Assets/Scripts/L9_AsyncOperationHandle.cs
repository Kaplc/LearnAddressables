using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace L1配置和使用
{
    public class L9_AsyncOperationHandle: MonoBehaviour
    {
        private void Start()
        {
            #region 无类型转有类型

            AsyncOperationHandle handle = Addressables.LoadAssetAsync<GameObject>("BossPanel");
            AsyncOperationHandle<GameObject> tHandle = handle.Convert<GameObject>();

            #endregion
        }
    }
}