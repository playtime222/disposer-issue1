//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using Metalama.Framework.Aspects;
//using Xunit;

//namespace Disposer.Tests
//{
//    [CompileTime]
//    public class DictionaryDetectionTests
//    {
//        private void Find<T>()
//        {
//            Assert.True(new DisposeActionDictionary().CanKill(typeof(T)));
//        }

//        private void DoNotFind<T>()
//        {
//            Assert.False(new DisposeActionDictionary().CanKill(typeof(T)));
//        }

//        [Fact]
//        public void IDictionaryKT()
//        {
//            Find<IDictionary<int, IDisposable>>();
//        }

//        [Fact]
//        public void DictionaryKT()
//        {
//            Find<Dictionary<int, IDisposable>>();
//        }

//        [Fact]
//        public void DictionaryKT2()
//        {
//            Find<Dictionary<object, IDisposable>>();
//        }

//        //[TestMethod]
//        //public void IEnumerableKeyValuePairKT()
//        //{
//        //    Find<IEnumerable<KeyValuePair<int, IDisposable>>>();
//        //}

//        //[TestMethod]
//        //public void ICollectionKeyValuePairKT()
//        //{
//        //    Find<ICollection<KeyValuePair<int, IDisposable>>>();
//        //}

//        [Fact]
//        public void Tuple()
//        {
//            DoNotFind<Tuple<KeyValuePair<int, IDisposable>, int, object>>();
//        }

//        //[TestMethod]
//        //public void IReadOnlyCollectionKeyValuePairKT()
//        //{
//        //    Find<IReadOnlyCollection<KeyValuePair<int, IDisposable>>>();
//        //}

//        [Fact]
//        public void IDictionaryIntInt()
//        {
//            DoNotFind<IDictionary<int, int>>();
//        }

//        [Fact]
//        public void IDictionaryOO()
//        {
//            DoNotFind<IDictionary<object, object>>();
//        }

//        [Fact]
//        public void IEnumerableIDisposable()
//        {
//            DoNotFind<IEnumerable<IDisposable>>();
//        }

//        [Fact]
//        public void IDictionaryKSafeHandle()
//        {
//            Find<IDictionary<int, SafeHandle>>();
//        }

//        //[TestMethod]
//        //public void RODictionaryKT()
//        //{
//        //    Find<IReadOnlyDictionary<int, IDisposable>>();
//        //}
//    }
//}