using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L11_�������� : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ����������ʲô���ã�
        //����������һ���ռ���Ŀ��Ѱַ������Ϣ�Ĺ���
        //����һ����Ϣ���ߣ����������ǶԿ�Ѱַ�ļ��������������ǵľ���
        #endregion

        #region ֪ʶ��� �򿪷�������
        //1.Window > Asset Management > Addressables > Analyze
        //2.Addressabeles Groups > Window > Analyze
        #endregion

        #region ֪ʶ���� ʹ�÷�������
        //�Ϸ���������ť
        //1.Analyze Selected Rules:����ѡ���Ĺ���
        //2.Clear Selected Rules:���ѡ������
        //3.Fix Selected Rules���޸�ѡ������

        //�·�������
        //Analyze Rules:��������
        //-Fixable Rules:���޸��Ĺ����ṩ�˷������޸����ֹ��ܵĹ�����������
        //--Check Duplicate Bundle Dependencies:����ظ���AB��������
        //��Ҫ��⴦������⣺
        //������Դa��b����ʹ���˲���c��a��b�ǿ�Ѱַ��Դ��c���ǿ�Ѱַ��Դ
        //a��b�ֱ�������AB���У���ô��ʱ����AB���ж�������Դc����ʱ�Ϳ���ͨ���ù����Ų��������
        //��ô��ʱ���ǿ���ѡ���Լ����´��������Ҳ����ѡ���޸�����
        //����ʹ���Լ��������⣬��ΪĳЩ���������Ҳ����Ϊ������
        //���磬һ��FBX���ж��������Ϣa��b����ʱ���Ƿֱ������a�����A������b�����B
        //��Ҳ����ΪA��B���ظ���Դ������ʵ���ǲ�û���ظ�

        //Unfixable Rules:�����޸��Ĺ��򣨶���ֻ�з������ܣ�û���޸����ܵĹ�����������֣�
        //-Check Resources to Addressable Duplicate Dependencies:����Ѱַ�ظ����������Դ
        //��Ҫ��������:
        //ͬʱ�����ڿ�Ѱַ��Դ��Ӧ�ó��򹹽�����Դ��
        //����һ����ԴA�����ǿ�Ѱַ��Դ
        //������ͬʱ��Resources��StreamingAssets�������ļ����У����ջᱻ�����ȥ


        //-Check Scene to Addressable Duplicate Dependencies:��鳡������Ѱַ�ظ�������
        //��Ҫ�������⣺
        //ͬʱ�����ڿ�Ѱַ��Դ��ĳһ��������
        //����һ����ԴA�����ǿ�Ѱַ��Դ��������ֱ�ӳ�����ĳһ��������
        //��ʱ����Ҫ�Լ�����������д���

        //-Bundle Layout Preview:AB������Ԥ��

        //1.������ѡ��һ������󣬿��Ե���Ϸ��� ����ѡ������ť ���з���
        //  ������ɺ󣬻����·�������Ӧ����Ϣ
        //2.����Ҳ���Ե�����ѡ���Ĺ�����������һ����Ϣ
        //3.�����ṩ���޸������Ĺ������ǿ��Ե���޸�ѡ���������޸�����

        //����Ҳ�����Լ������������
        //�������ָ߼���ʽ���ǲ����ر���
        //����Բο��ٷ��ĵ���
        //https://docs.unity.cn/Packages/com.unity.addressables@1.18/manual/AnalyzeTool.html
        //Extending Analyze��չ������ص�����
        //�˽⼴��
        #endregion

        #region �ܽ�
        //�������ڶ���������˵Ҳ������
        //�����Ǵ�������ǿ���ͨ���������ڹ���
        //����AB���е���Դ�ֲ��Ƿ����
        //���ݷ�������Լ�����һЩǱ������
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
