namespace Lym.Common.MS
{
    internal class SM4_Context
    {
        public int mode;

        public long[] sk;

        public bool isPadding;

        public SM4_Context()
        {
            this.mode = 1;
            this.isPadding = true;
            this.sk = new long[32];
        }
    }
}