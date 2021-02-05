using Microsoft.VisualStudio.TestTools.UnitTesting;
using FestivalManager;
using System;
using System.Collections.Generic;

namespace FestivalManagerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TimeSpan t1 = new TimeSpan(0, 3, 18);
            Song s1 = new Song("czarne oczy", t1);
            Assert.AreEqual(s1.Name, "czarne oczy");
            Assert.AreEqual(s1.Duration, t1);
            Assert.AreEqual(s1.ToString(), "czarne oczy (03:18)");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Performer p1 = new Performer("Adrian", "Rora", 21);
            Assert.AreEqual(p1.FullName, "Adrian Rora");
            Assert.AreEqual(p1.ToString(), "Adrian Rora");
            Assert.AreEqual(p1.Age, 21);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Stage s1 = new Stage();
            Performer p1 = new Performer("Adrian", "Rora", 21);
            Performer p2 = new Performer("Julia", "Rora", 22);
            var expected = new List<Performer>();
            expected.Add(p1);
            expected.Add(p2);
            s1.AddPerformer(p1);
            s1.AddPerformer(p2);
            CollectionAssert.AreEqual(expected, (System.Collections.ICollection)s1.Performers);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Stage s1 = new Stage();
            Performer p1 = new Performer("Adrian", "Rora", 10);
            try
            {
                s1.AddPerformer(p1);
                Assert.Fail();
            } catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "You can only add performers that are at least 18.");
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            Stage s1 = new Stage();
            Performer p1 = null;
            try
            {
                s1.AddPerformer(p1);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Can not be null! (Parameter 'performer')", e.Message);
            }
        }
        [TestMethod]

        public void TestMethod6()
        {
            Stage s1 = new Stage();
            Song song = null;
            try
            {
                s1.AddSong(song);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Can not be null! (Parameter 'song')", e.Message);
            }
        }
        [TestMethod]
        public void TestMethod7()
        {
            Stage s1 = new Stage();
            TimeSpan t1 = new TimeSpan(0, 0, 18);
            Song song1 = new Song("czarne oczy", t1);
            try
            {
                s1.AddSong(song1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "You can only add songs that are longer than 1 minute.");
            }
        }
    }
}
