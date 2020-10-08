using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            _controls.Enqueue(new Label());
            _controls.Enqueue(new Button());
            _controls.Enqueue(new CheckBox());
            _controls.Enqueue(new TextBox());
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
                Assert.DoesNotThrow(() => InvokeControl.SetBackground(control, Brushes.Transparent));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetBackground(control, Brushes.Transparent)));
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
                Assert.DoesNotThrow(() => InvokeControl.SetForeground(control, Brushes.Transparent));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetForeground(control, Brushes.Transparent)));
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
                Assert.DoesNotThrow(() => InvokeControl.SetIsEnabled(control, true));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetIsEnabled(control, true)));
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
                Assert.DoesNotThrow(() => InvokeControl.SetVisibility(control, Visibility.Visible));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetVisibility(control, Visibility.Visible)));
            }
            TestContext.WriteLine($@"{nameof(SetVisibility_DoesNotThrow)} complete.");
        }
    }
}