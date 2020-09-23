using LibBaseSequence;
using HashTool.Measurement;
using HashTool.Condition;
using System.IO;
using System.Reflection;
using System;

namespace HashTool
{
    public sealed class Sequence : SequenceBase<Parameter, Result>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="word"></param>
        /// <param name="condition"></param>
        public Sequence (string _word, int _condition = 0) : base()
        {
            Parameter.Word = _word;
            Conditions.Condition = _condition;
            string CurrentPath = Directory.GetCurrentDirectory();
            string AssemblyName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".xml";
            string XML_PATH = Path.Combine(CurrentPath, AssemblyName);
            Console.WriteLine(CurrentPath);
            Console.WriteLine(AssemblyName);
            Console.WriteLine(XML_PATH);
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(Assembly.GetExecutingAssembly());
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine();
        }

        private string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度

            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }

            return _FolderPath;
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public override void PreProcess ( )
        {
            // パラメータ設定
            Parameter.SetParam( );

            // 結果初期化
            Result.Init( );
        }

        /// <summary>
        /// 本体処理
        /// </summary>
        public override void BodyProcess ( )
        {
            // HashTool本体処理
            var measure = MeasurementFactory.Get( );
            measure.Exec( );
            Result.HashValue = measure.HashValue;
        }

        /// <summary>
        /// 事後プロセス
        /// </summary>
        public override void PostProcess ( ) 
        { 
            Result.Condition = Conditions.Condition;
        }

        /// <summary>
        /// リトライプロセス
        /// HashToolリトライしないようにする
        /// </summary>
        public override void RetryProcess ( ) { }
    }
}
