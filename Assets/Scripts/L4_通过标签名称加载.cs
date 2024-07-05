using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace L1配置和使用
{
    public class L4_通过标签名称加载 : MonoBehaviour
    {
        public TMP_Text text;
        
        private void Start()
        {
            #region 标签或名称加载单个资源

            // 可以标签或名称可以结合泛型确定, 只能加载第一个满足条件的资源
            AsyncOperationHandle nameHandle = Addressables.LoadAssetAsync<GameObject>("BossMonster0");
            nameHandle.Completed += operationHandle =>
            {
                if (operationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("L4单资源名称加载成功");
                    Addressables.Release(nameHandle);
                    text.text += $"L4单资源名称加载成功\n";
                }
                else
                {
                    Debug.Log("L4单资源名称加载失败");
                    text.text += $"L4单资源名称加载失败\n";
                }
            };

            AsyncOperationHandle labelHandle = Addressables.LoadAssetAsync<GameObject>("UI");
            labelHandle.Completed += operationHandle =>
            {
                if (operationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("L4单资源标签加载成功");
                    Addressables.Release(labelHandle);
                    text.text += $"L4单资源标签加载成功\n";
                }
                else
                {
                    Debug.Log("L4单资源标签加载失败");
                    text.text += $"L4单资源标签加载失败\n";
                }
            };

            #endregion

            #region 加载场景

            // AsyncOperationHandle sceneHandle = Addressables.LoadSceneAsync("Scene");
            // sceneHandle.Completed += handle =>
            // {
            //     if (handle.Status == AsyncOperationStatus.Succeeded)
            //     {
            //         Debug.Log("加载场景成功");
            //     }
            // };

            #endregion

            #region 加载多个资源

            //加载多个资源
            //参数一：资源名或标签名
            //参数二：加载结束后的回调函数
            //参数三：如果为true表示当资源加载失败时，会自动将已加载的资源和依赖都释放掉；如果为false，需要自己手动来管理释放
            AsyncOperationHandle<IList<GameObject>> handles =
                Addressables.LoadAssetsAsync<GameObject>("UI", handle => { Debug.Log("多资源加载完成" + handle.name); });
            // 
            handles.Completed += list =>
            {
                foreach (var o in list.Result)
                {
                    Debug.Log("handles.Completed +=回调释放" + o.name);
                    text.text += $"handles.Completed +=回调释放{o.name}\n";
                }

                Addressables.Release(list);
            };


            // 联合筛选
            //参数一：想要加载资源的条件列表（资源名、Lable名）
            //参数二：每个加载资源结束后会调用的函数，会把加载到的资源传入该函数中
            //参数三：可寻址的合并模式，用于合并请求结果的选项。
            //如果键（Cube，Red）映射到结果（[1,2,3]，[1,3,4]），数字代表不同的资源
            //None：不发生合并，将使用第一组结果 结果为[1,2,3]
            //UseFirst：应用第一组结果 结果为[1,2,3]
            //Union：合并所有结果 结果为[1,2,3,4]
            //Intersection：使用相交结果 结果为[1,3]
            //参数四：如果为true表示当资源加载失败时，会自动将已加载的资源和依赖都释放掉
            //      如果为false，需要自己手动来管理释放
            AsyncOperationHandle<IList<Object>> handles2 = Addressables.LoadAssetsAsync<Object>(
                new List<string> { "UI", "BossPanel" },
                o =>
                {
                    if (o.name == "BossPanel")
                    {
                        if ((o as GameObject).transform.Find("Update"))
                        {
                            Debug.Log("更新成功");
                            text.text += "更新成功\n";
                        }
                    }
                    Debug.Log("联合筛选" + o.name);
                    text.text += $"联合筛选{o.name}\n";
                },
                Addressables.MergeMode.Union
            );

            #endregion
        }
    }
}