namespace CommonLib.Common
{
    public enum E_FUNCTION_STATUS
    {
        INIT,       /* 未処理 　*/
        SUCCESS,    /* 処理成功 */
        ABORT,      /* 処理中止 */
        FAILED      /* 処理失敗 */
    }

    public class Common
    {
        public static bool MAS_Yes = true;
        public static bool MAS_No = false;

        public static int SHIFT_8   = 8;
        public static int SHIFT_16  = 16;
        public static int SHIFT_24  = 24;
        public static int SHIFT_28  = 28;
        public static int SHIFT_30  = 30;

        public static int MASK_BIT_0_7      = 0x000000FF;
        public static int MASK_BIT_8_15     = 0x0000FF00;
        public static int MASK_BIT_16_23    = 0x00FF0000;
        public static int MASK_BIT_24_27    = 0x0F000000;
        public static int MASK_BIT_28_29    = 0x30000000;
        public static int MASK_BIT_30       = 0x40000000;
    }
}
