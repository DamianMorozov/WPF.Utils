using NUnit.Framework;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeTextBoxTests
    {
        #region Private fields and properties

        private ConcurrentQueue<TextBox> _controls;

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
            _controls = new ConcurrentQueue<TextBox>();
            for (var i = 0; i < 100; i++)
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
        public void Clear_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Clear_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.Clear(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.Clear(control)));
            }
            TestContext.WriteLine($@"{nameof(Clear_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(AddText_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.AddText(control, "test 1"));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddText(control, "test 2")));
            }
            TestContext.WriteLine($@"{nameof(AddText_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddTextFormat_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(AddTextFormat_DoesNotThrow)} start.");
            var sw = Stopwatch.StartNew();
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.AddTextFormat(control, sw, "test 1"));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddTextFormat(control, sw, "test 2")));
            }
            sw.Stop();
            TestContext.WriteLine($@"{nameof(AddTextFormat_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void GetText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetText_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.GetText(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.GetText(control)));
            }
            TestContext.WriteLine($@"{nameof(GetText_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetText_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.SetText(control, "test 1"));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.SetText(control, "test 2")));
            }
            TestContext.WriteLine($@"{nameof(SetText_DoesNotThrow)} complete.");
        }
    }
}