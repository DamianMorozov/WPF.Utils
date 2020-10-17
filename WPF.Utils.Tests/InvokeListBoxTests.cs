﻿using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeListBoxTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ListBox> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _controls = new ConcurrentQueue<ListBox>();
            for (var i = 0; i < 10; i++)
                _controls.Enqueue(new ListBox());
            TestContext.WriteLine($@"{nameof(Setup)} complete.");
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        [Apartment(ApartmentState.STA)]
        public void Teardown()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Teardown)} start.");
            while (_controls.TryDequeue(out _)) { }
            TestContext.WriteLine($@"{nameof(Teardown)} complete.");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }



        [Test]
        [Apartment(ApartmentState.STA)]
        public void ItemsClear_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ListBox control))
            {
                Assert.DoesNotThrow(() => InvokeListBox.ItemsClear(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemsClear(control)));
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ItemAdd_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ListBox control))
            {
                foreach (var value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeListBox.ItemAdd(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemAdd(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ItemsAdd_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ListBox control))
            {
                Assert.DoesNotThrow(() => InvokeListBox.ItemsAdd(control, null));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemsAdd(control, null)));
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ItemsGet_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ListBox control))
            {
                Assert.DoesNotThrow(() => InvokeListBox.ItemsGet(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemsGet(control)));
            }
            Utils.MethodComplete();
        }
    }
}