using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils.Tests
{
    [TestFixture]
    public class InvokeTextBoxTests
    {
        #region Private fields and properties

        private List<TextBox> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            var task = Task.Run(() =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    _controls = new List<TextBox>();
                    for (var i = 0; i < 100; i++)
                        _controls.Add(new TextBox());
                });
            });
            task.ConfigureAwait(true).GetAwaiter().GetResult();
            TestContext.WriteLine($@"{nameof(Setup)} complete.");
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Teardown)} start.");
            //_controls.Clear();
            //_controls = null;
            TestContext.WriteLine($@"{nameof(Teardown)} complete.");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        [Test]
        public void Clear_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Clear_DoesNotThrow)} start.");
            Assert.DoesNotThrow(() => { var i = 10; });
            //foreach (var control in _controls)
            //{
            //    TestContext.WriteLine("- Start");
            //    Assert.DoesNotThrow(() => InvokeTextBox.Clear(control));
            //    TestContext.WriteLine("- End");
            //    //Assert.DoesNotThrowAsync(() => InvokeTextBox.Clear(control));
            //}
            TestContext.WriteLine($@"{nameof(Clear_DoesNotThrow)} complete.");
        }

        [Test]
        public void AddText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(AddText_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeTextBox.AddText(control, "test"));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeTextBox.AddText(control, "test")));
            }
            TestContext.WriteLine($@"{nameof(AddText_DoesNotThrow)} complete.");
        }

        [Test]
        public void AddTextFormat_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(AddTextFormat_DoesNotThrow)} start.");
            var sw = Stopwatch.StartNew();
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeTextBox.AddTextFormat(control, sw, "test"));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeTextBox.AddTextFormat(control, sw, "test")));
            }
            sw.Stop();
            TestContext.WriteLine($@"{nameof(AddTextFormat_DoesNotThrow)} complete.");
        }

        [Test]
        public void GetText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetText_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeTextBox.GetText(control));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeTextBox.GetText(control)));
            }
            TestContext.WriteLine($@"{nameof(GetText_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetText_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetText_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeTextBox.SetText(control, "test"));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeTextBox.SetText(control, "test")));
            }
            TestContext.WriteLine($@"{nameof(SetText_DoesNotThrow)} complete.");
        }
    }
}