using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;


public interface IAddressablesManager
{
    void LoadAssetAsync<T>(string name, Action<T> callBack)  where T: class;
    void LoadAssetAsync<T>(Action<T> callBack, params string[] keys)  where T: class;
    void LoadAssetsAsync<T>(Addressables.MergeMode mode, Action<IList<T>> callBack, params string[] keys) where T : class;
    void Release<T>(string name);
    void Release<T>(params string[] keys);
    void Clear();
}