using System;

namespace CommonLib.EnumExtension
{
    public static class EnumExtension
    {
        public static bool GenerateToEnum<T> (ref T result)
            where T : Enum
        {
            bool rel = false;   // 関数の戻り値

            do
            {
                try
                {
                    var values = Enum.GetValues(typeof(T));
                    result = (T)values.GetValue(new Random( ).Next(values.Length));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                rel = true;
            } while(false);

            return rel;
        }

        /// <summary>
        /// byte型をenumに変換する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool ConvertToEnum<T> (byte value, ref T result)
            where T : Enum
        {
            bool rel = false;  // 関数の戻り値
            do
            {
                var enumType = typeof(T);
                try
                {
                    // EnumTypeにvalue値を定義するかをチェック
                    if(!Enum.IsDefined(enumType, value)) break;

                    // EnumTypeに変換する
                    result = (T)Enum.ToObject(enumType, value);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            return rel;
        }

        /// <summary>
        /// int型をenumに変換する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool ConvertToEnum<T> (int value, ref T result)
            where T : Enum
        {
            bool rel = false;  // 関数の戻り値
            do
            {
                var enumType = typeof(T);
                try
                {
                    // EnumTypeにvalue値を定義するかをチェック
                    if(!Enum.IsDefined(enumType, value))
                        break;

                    // EnumTypeに変換する
                    result = (T)Enum.ToObject(enumType, value);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            return rel;
        }

        /// <summary>
        /// enum名を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetName<T> (T value, ref string name)
            where T : Enum
        {
            bool rel = false;          // 関数の戻り値
            do
            {
                try
                {
                    // 获取枚举常数名称。
                    name = Enum.GetName(typeof(T), value);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                    // 異常終了
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            return rel;
        }
    }
}
