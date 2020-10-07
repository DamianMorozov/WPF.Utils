using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    public class InvokeProgressBarTests
    {
        #region Private fields and properties

        private List<ProgressBar> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _controls = new List<ProgressBar>();
            for (var i = 0; i < 100; i++)
            {
                _controls.Add(new ProgressBar());
            }
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
        public void SetMaximum_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetMaximum_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeProgressBar.SetMaximum(control, 100));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeProgressBar.SetMaximum(control, 100)));
            }
            TestContext.WriteLine($@"{nameof(SetMaximum_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetMinimum_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetMinimum_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeProgressBar.SetMinimum(control, 0));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeProgressBar.SetMinimum(control, 0)));
            }
            TestContext.WriteLine($@"{nameof(SetMinimum_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetValue_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetValue_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeProgressBar.SetValue(control, 50));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeProgressBar.SetValue(control, 50)));
            }
            TestContext.WriteLine($@"{nameof(SetValue_DoesNotThrow)} complete.");
        }
    }
}