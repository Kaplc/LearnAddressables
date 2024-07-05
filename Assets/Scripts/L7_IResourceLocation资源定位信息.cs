using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace L1配置和使用
{
    public class L7_IResourceLocation资源定位信息 : MonoBehaviour
    {
        private void Start()
        {
            #region IResourceLocation加载资源

            AsyncOperationHandle<IList<IResourceLocation>> handle = Addressables.LoadResourceLocationsAsync("UI", typeof(GameObject));
            handle.Completed += operationHandle =>
            {
                if (operationHandle.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError("IResourceLocation加载资源失败");
                    return;
                }

                foreach (IResourceLocation resourceLocation in operationHandle.Result)
                {
                    Addressables.LoadAssetAsync<GameObject>(resourceLocation).Completed += obj =>
                    {
                        //  PrimaryKey：资源主键（资源名）
                        //  InternalId：资源内部ID（资源路径）
                        //  ResourceType：资源类型（Type可以获取资源类型名）

                        if (obj.Status != AsyncOperationStatus.Succeeded)
                        {
                            Debug.LogError(resourceLocation.PrimaryKey +
                                           "-" + resourceLocation.InternalId +
                                           "-" + resourceLocation.ResourceType
                                           + " 加载失败");
                        }

                        Debug.Log(resourceLocation.PrimaryKey +
                                  "-" + resourceLocation.InternalId +
                                  "-" + resourceLocation.ResourceType
                                  + " 加载成功");
                    };
                }
            };

            // 联合筛选
            AsyncOperationHandle<IList<IResourceLocation>> handle2 = Addressables.LoadResourceLocationsAsync(new List<string>
            {
                "UI", "BossPanel"
            }, Addressables.MergeMode.Intersection, typeof(GameObject));
            handle2.Completed += operationHandle =>
            {
                if (operationHandle.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError("联合筛选IResourceLocation加载资源失败");
                    return;
                }

                foreach (IResourceLocation resourceLocation in operationHandle.Result)
                {
                    Addressables.LoadAssetAsync<GameObject>(resourceLocation).Completed += obj =>
                    {
                        if (obj.Status != AsyncOperationStatus.Succeeded)
                        {
                            Debug.LogError(resourceLocation.PrimaryKey +
                                           "-" + resourceLocation.InternalId +
                                           "-" + resourceLocation.ResourceType
                                           + " 联合筛选加载失败");
                        }

                        Debug.Log(resourceLocation.PrimaryKey +
                                  "-" + resourceLocation.InternalId +
                                  "-" + resourceLocation.ResourceType
                                  + " 联合筛选加载成功");
                    };
                }
            };

            #endregion
        }
    }
}