/**
* ��    �ߣ�������(zhi_dian@163.com)
* ����ʱ�䣺2010-03-29 13:33:00
* �� �� �ţ�1.0.0
* ����˵������������ӿ�(���ݿ�ORDER BY)
* ----------------------------------
 */
using System.Collections.Generic;
using DotNet.Standard.NParsing.Factory;
using DotNet.Standard.NParsing.Utilities;

namespace DotNet.Standard.NParsing.Interface
{
    public interface IObSort
    {
        /// <summary>
        /// �����ֶ��б�
        /// </summary>
        IList<DbSort> List { get; }

        /// <summary>
        /// ���һ���������
        /// </summary>
        /// <param name="obProperty">����</param>
        /// <returns></returns>
        IObSort AddOrderBy(ObProperty obProperty);
        IObSort AddOrderByDescending(ObProperty obProperty);

        /// <summary>
        /// ��Ӷ���������
        /// </summary>
        /// <param name="obPropertys"></param>
        /// <returns></returns>
        IObSort AddOrderBy(params ObProperty[] obPropertys);
        IObSort AddOrderByDescending(params ObProperty[] obPropertys);

        IObSort Add(IObSort obSort);
        /// <summary>
        /// ��Ӷ���������
        /// </summary>
        /// <param name="obSorts"></param>
        /// <returns></returns>
        IObSort Add(params IObSort[] obSorts);

        /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        /// <returns></returns>
        string ToString();

        string ToString(char separator);

        string ToString(IList<string> columnNames);

        string ToString(char separator, IList<string> columnNames);

        /// <summary>
        /// ��ʶ
        /// </summary>
        string Key { get; }
    }
}