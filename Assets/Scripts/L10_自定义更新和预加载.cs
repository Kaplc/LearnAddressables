using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace L1配置和使用
{
    public class L10_自定义更新和预加载: MonoBehaviour
    {
        private void Start()
        {
            #region 手动更新目录
        
            //1.如果要手动更新目录 建议在设置中关闭自动更新

            // 手动检查、手动更新
            Addressables.CheckForCatalogUpdates().Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    // 大于0说明有
                    if (handle.Result.Count > 0)
                    {
                        Addressables.UpdateCatalogs(handle.Result).Completed += operationHandle =>
                        {
                            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
                            {
                                Debug.Log("手动检查手动更新");
                            }
                            else
                            {
                                Debug.LogWarning("目录更新失败: " + operationHandle.OperationException);
                            }
                        };
                    }
                }
                else
                {
                    Debug.LogWarning("检查目录更新失败: " + handle.OperationException);
                }
            };

            #endregion

            #region 预加载

            StartCoroutine(Preloading());

            #endregion
        }

        private IEnumerator Preloading()
        {
            // 获取资源大小
            AsyncOperationHandle<long> sizeHandle = Addressables.GetDownloadSizeAsync("BossPanel");
            yield return sizeHandle;

            if (sizeHandle.Status == AsyncOperationStatus.Succeeded && sizeHandle.Result > 0)
            {
                // 加载所有依赖
                AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync("BossPanel");

                while (!downloadHandle.IsDone)
                {
                    Debug.Log(downloadHandle.GetDownloadStatus().Percent);
                    yield return null;
                }

                if (downloadHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("预加载加载成功");
                }
                else
                {
                    Debug.LogWarning("预加载加载失败: " + downloadHandle.OperationException);
                }

                // 释放操作句柄
                Addressables.Release(downloadHandle);
            }
            else if (sizeHandle.Status == AsyncOperationStatus.Failed)
            {
                Debug.LogWarning("获取资源大小失败: " + sizeHandle.OperationException);
            }

            // 释放大小获取句柄
            Addressables.Release(sizeHandle);
        }
    }
    
}