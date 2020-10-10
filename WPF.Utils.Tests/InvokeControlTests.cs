using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeControlTests
    {
        #region Private fields and properties

        private ConcurrentQueue<Control> _controls;

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
            _controls = new ConcurrentQueue<Control>();
            for (int i = 0; i < 10; i++)
            {
                _controls.Enqueue(new Label());
                _controls.Enqueue(new Button());
                _controls.Enqueue(new CheckBox());
                _controls.Enqueue(new TextBox());
            }
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
        public void Focus_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Focus_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                Assert.DoesNotThrow(() => InvokeControl.Focus(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.Focus(control)));
            }
            TestContext.WriteLine($@"{nameof(Focus_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetBackground_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetBackground_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumWPF.GetBrush())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetBackground(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetBackground(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetBackground_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetForeground_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetForeground_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumWPF.GetBrush())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetForeground(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetForeground(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetForeground_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetIsEnabled_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetIsEnabled_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumValues.GetBool())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetIsEnabled(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetIsEnabled(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetIsEnabled_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetVisibility_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetVisibility_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                foreach (Visibility value in Enum.GetValues(typeof(Visibility)))
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetVisibility(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetVisibility(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetVisibility_DoesNotThrow)} complete.");
        }
    }
}