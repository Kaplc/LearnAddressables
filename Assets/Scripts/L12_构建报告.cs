using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L12_构建报告 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 构建布局报告有什么作用？
        //构建布局报告提供了有关可寻址资源的构建打包的详细信息和统计信息
        //包括
        //1.AB包的描述
        //2.每个资源和AB包的大小
        //3.解析作为依赖项隐式包含在AB包中的不可寻址资源
        //4.AB包的依赖关系

        //我们可以通过查看报告文件获取这些信息
        #endregion

        #region 知识点二 如何查看构建布局报告？
        //1.启用调试构建布局功能
        //Edit > Preferences > Addressables
        //启用Debug Build Layout

        //2.只要我们构建打包可寻址资源后
        //就可以在Library/com.unity.addressables/文件夹中找到buildlayout.txt文件
        #endregion

        #region 知识点三 构建布局报告的内容
        //内容中主要包含：
        //1.摘要信息(包括AB包数量、大小等等)
        //2.每组相关信息（哪些资源，几个包，包大小等等）
        //3.依赖相关信息
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
