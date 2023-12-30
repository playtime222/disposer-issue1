using System;
using System.Linq;

namespace TestProject1
{

    //ncrunch: no coverage start
    public class ReflectionTestTarget
    {
        public void PublicFunction()
        {
        }

        protected void ProtectedFunction()
        {
        }

        private void PrivateFunction()
        {
        }

        internal void InternalFunction()
        {
        }

        protected internal void ProtectedInternalFunction()
        {
        }

        public int Getter { get; }

        private int _Setter;

        public int Setter
        {
            set { _Setter = value; }
        }
    }
}