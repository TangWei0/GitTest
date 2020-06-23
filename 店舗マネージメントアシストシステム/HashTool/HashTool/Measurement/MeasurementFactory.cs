using HashTool.Constant;
using HashTool.Condition;
using LibBaseSequence;

namespace HashTool.Measurement
{
    public static class MeasurementFactory
    {
        public static MeasureBase Get ( )
        {
            var type = Conditions.Type;
            switch(type)
            {
                case E_HASH_TYPE.MD5:
                    return new MeasureMD5( );
                case E_HASH_TYPE.SHA1:
                    return new MeasureSHA1( );
                case E_HASH_TYPE.SHA256:
                    return new MeasureSHA256( );
                case E_HASH_TYPE.SHA384:
                    return new MeasureSHA384( );
                case E_HASH_TYPE.SHA512:
                    return new MeasureSHA512( );
                default:
                    throw new ProcessException(
                        string.Format("HashToolの実行異常　Hashタイプ異常 type = {0}", type.ToString()));
            }
        }
    }
}
