using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace L1配置和使用
{
    public class Test : MonoBehaviour
    {
        private AddressablesesManager addressablesesManager;

        private void Start()
        {
            addressablesesManager = new AddressablesesManager();

            addressablesesManager.LoadAssetAsync<GameObject>("BossPanel", obj =>
            {
                if (obj)
                {
                    Debug.Log("加载完成" + obj.name);
                }
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                addressablesesManager.LoadAssetAsync<GameObject>("BossPanel", obj =>
                {
                    if (obj)
                    {
                        Debug.Log("j加载完成" + obj.name);
                    }
                });
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                addressablesesManager.LoadAssetAsync<GameObject>(obj =>
                {
                    if (obj)
                    {
                        Debug.Log("o加载完成" + obj.name);
                    }
                }, "BossGamePanel", "UI");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                addressablesesManager.LoadAssetsAsync<GameObject>(Addressables.MergeMode.Union, list =>
                {
                    if (list.Count > 0)
                    {
                        Debug.Log(list.Count);
                    }
                }, "UI");
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                addressablesesManager.Release<GameObject>("UI");
                addressablesesManager.Release<GameObject>("BossPanel");
                addressablesesManager.Release<GameObject>("BossGamePanel", "UI");
            }
        }
    }
}