using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L11_分析窗口 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 分析窗口有什么作用？
        //分析窗口是一种收集项目可寻址布局信息的工具
        //它是一种信息工具，可以让我们对可寻址文件布局做出更明智的决定
        #endregion

        #region 知识点二 打开分析窗口
        //1.Window > Asset Management > Addressables > Analyze
        //2.Addressabeles Groups > Window > Analyze
        #endregion

        #region 知识点三 使用分析窗口
        //上方的三个按钮
        //1.Analyze Selected Rules:分析选定的规则
        //2.Clear Selected Rules:清除选定规则
        //3.Fix Selected Rules：修复选定规则

        //下方的内容
        //Analyze Rules:分析规则
        //-Fixable Rules:可修复的规则（提供了分析和修复两种功能的规则出现在这里）
        //--Check Duplicate Bundle Dependencies:检查重复的AB包依赖项
        //主要检测处理的问题：
        //比如资源a和b，都使用了材质c，a和b是可寻址资源，c不是可寻址资源
        //a，b分别在两个AB包中，那么这时两个AB包中都会有资源c，这时就可以通过该规则排查出该问题
        //那么这时我们可以选择自己重新处理后打包，也可以选择修复功能
        //建议使用自己处理问题，因为某些特殊情况它也会认为有问题
        //比如，一个FBX中有多个网格信息a，b，这时我们分别把网格a放入包A，网格b放入包B
        //它也会认为A和B有重复资源，但其实他们并没有重复

        //Unfixable Rules:不可修复的规则（对于只有分析功能，没有修复功能的规则在这里出现）
        //-Check Resources to Addressable Duplicate Dependencies:检查可寻址重复依赖项的资源
        //主要检测的问题:
        //同时出现在可寻址资源和应用程序构建的资源中
        //比如一个资源A，它是可寻址资源
        //但是它同时在Resources、StreamingAssets等特殊文件夹中，最终会被打包出去


        //-Check Scene to Addressable Duplicate Dependencies:检查场景到可寻址重复依赖项
        //主要检测的问题：
        //同时出现在可寻址资源和某一个场景中
        //比如一个资源A，它是可寻址资源但是它有直接出现在某一个场景中
        //这时你需要自己根据需求进行处理

        //-Bundle Layout Preview:AB包布局预览

        //1.当我们选中一个规则后，可以点击上方的 分析选定规则按钮 进行分析
        //  分析完成后，会在下方看到对应的信息
        //2.我们也可以点击清除选定的规则可以清除上一次信息
        //3.对于提供了修复操作的规则，我们可以点击修复选定规则，来修复问题

        //我们也可以自己定义分析规则
        //但是这种高级方式我们不是特别常用
        //你可以参考官方文档：
        //https://docs.unity.cn/Packages/com.unity.addressables@1.18/manual/AnalyzeTool.html
        //Extending Analyze拓展分析相关的内容
        //了解即可
        #endregion

        #region 总结
        //分析窗口对于我们来说也很有用
        //当我们打包后，我们可以通过分析窗口工具
        //分析AB包中的资源分布是否合理
        //根据分析结果自己处理一些潜在问题
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
