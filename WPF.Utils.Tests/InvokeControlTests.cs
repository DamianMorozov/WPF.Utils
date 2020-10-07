using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.Utils.Tests
{
    [TestFixture]
    public class InvokeControlTests
    {
        #region Private fields and properties

        private List<Control> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _controls = new List<Control>
            {
                new Label(), new Button(), new CheckBox(), new TextBox()
            };
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
        public void Focus_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Focus_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeControl.Focus(control));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeControl.Focus(control)));
            }
            TestContext.WriteLine($@"{nameof(Focus_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetBackground_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetBackground_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeControl.SetBackground(control, Brushes.Transparent));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeControl.SetBackground(control, Brushes.Transparent)));
            }
            TestContext.WriteLine($@"{nameof(SetBackground_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetForeground_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetForeground_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeControl.SetForeground(control, Brushes.Transparent));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeControl.SetForeground(control, Brushes.Transparent)));
            }
            TestContext.WriteLine($@"{nameof(SetForeground_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetIsEnabled_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetIsEnabled_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeControl.SetIsEnabled(control, true));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeControl.SetIsEnabled(control, true)));
            }
            TestContext.WriteLine($@"{nameof(SetIsEnabled_DoesNotThrow)} complete.");
        }

        [Test]
        public void SetVisibility_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetVisibility_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                Assert.DoesNotThrow(() => InvokeControl.SetVisibility(control, Visibility.Visible));
                Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeControl.SetVisibility(control, Visibility.Visible)));
            }
            TestContext.WriteLine($@"{nameof(SetVisibility_DoesNotThrow)} complete.");
        }
    }
}