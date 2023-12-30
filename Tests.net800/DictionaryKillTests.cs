//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;
//using Disposer.Testables;

//using Playtime222.PostsharpAspects.Disposer.Implementation;
//using Xunit;

//namespace Disposer.Tests
//{
//    class Victim
//    {
//        public IDictionary<int, IDisposable> Field1 = new Dictionary<int, IDisposable>();

//        public Dictionary<int, IDisposable> Field2 = new Dictionary<int, IDisposable>();

//        public Dictionary<int, FakeDisposable> Field3 = new Dictionary<int, FakeDisposable>();

//        public Victim()
//        {
//            Field4 = new ReadOnlyDictionary<int, IDisposable>(Field1);
//        }

//        public IReadOnlyDictionary<int, IDisposable> Field4;
//    }


//    public class DictionaryKillTests
//    {
//        [Fact]
//        public void IDictionaryKT()
//        {
//            var v = new Victim();
//            var fakeDisposable = new FakeDisposable();

//            v.Field1.Add(1, fakeDisposable);
//            typeof(Victim).GetField(nameof(Victim.Field1)).KillDictionaryWithValuesField(v, null);

//            Assert.True(fakeDisposable.Disposed);
//        }

//        [Fact]
//        public void DictionaryKT()
//        {
//            var v = new Victim();
//            var fakeDisposable = new FakeDisposable();

//            v.Field2.Add(1, fakeDisposable);
//            typeof(Victim).GetField(nameof(Victim.Field2)).KillDictionaryWithValuesField(v, null);

//            Assert.True(fakeDisposable.Disposed);
//        }

//        [Fact]
//        public void DictionaryKTFake()
//        {
//            var v = new Victim();
//            var fakeDisposable = new FakeDisposable();

//            v.Field3.Add(1, fakeDisposable);
//            typeof(Victim).GetField(nameof(Victim.Field3)).KillDictionaryWithValuesField(v, null);

//            Assert.True(fakeDisposable.Disposed);
//        }

//        [Fact]
//        public void IReadOnlyDictionaryKT()
//        {
//            var v = new Victim();
//            var fakeDisposable = new FakeDisposable();

//            v.Field1.Add(1, fakeDisposable);
//            typeof(Victim).GetField(nameof(Victim.Field4)).KillDictionaryWithValuesField(v, null);

//            Assert.True(fakeDisposable.Disposed);
//        }

      
//    }
//}