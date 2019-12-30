using static HashTool.HashHelper;
using static ClassLibrary.Enum;
using System;

namespace ComputeHash
{
    class Program
    {
        static void Main(string[] args)
        {
            E_FUNCTION_RESULT ret_fuction;
            string hash_value;

            do
            {
                ret_fuction = String_Hash_MD5_32("abc", E_HASH_PARAMETER.UPPER, out hash_value);
                if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
                {
                    break;
                }
                Console.WriteLine("MD5_32(Upper): {0}", hash_value);

                ret_fuction = String_Hash_MD5_32("abc", E_HASH_PARAMETER.LOWER, out hash_value);
                if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
                {
                    break;
                }
                Console.WriteLine("MD5_32(Upper): {0}", hash_value);
            } while(false);
        }
    }
}
