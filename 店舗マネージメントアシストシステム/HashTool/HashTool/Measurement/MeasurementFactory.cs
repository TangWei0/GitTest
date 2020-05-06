using HashTool.Constant;
using LibBaseSequence;

namespace HashTool.Measurement
{
    public static class MeasurementFactory
    {
        public static MeasureBase Get (Parameter parameter)
        {
            var type = parameter.GetCondition( ).GetHashType( );
            switch(type)
            {
                case E_HASH_TYPE.MD5:
                    return new MeasureMD5(parameter);
                case E_HASH_TYPE.SHA1:
                    return new MeasureSHA1(parameter);
                case E_HASH_TYPE.SHA256:
                    return new MeasureSHA256(parameter);
                case E_HASH_TYPE.SHA384:
                    return new MeasureSHA384(parameter);
                case E_HASH_TYPE.SHA512:
                    return new MeasureSHA512(parameter);
                default:
                    throw new ProcessException(
                        string.Format("HashToolの実行異常　Hashタイプ異常 type = {0}", type.ToString()));
            }
        }
    }
}
