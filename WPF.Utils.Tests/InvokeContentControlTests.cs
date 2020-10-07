using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    public class InvokeContentControlTests
    {
        #region Private fields and properties

        private List<ContentControl> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _controls = new List<ContentControl>
            {
                new Label(), //new Button(), new CheckBox()
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
        public void SetContent_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetContent_DoesNotThrow)} start.");
            foreach (var control in _controls)
            {
                //Assert.DoesNotThrow(() => InvokeContentControl.SetContent(control, "test"));
                //Assert.DoesNotThrowAsync(() => Task.Run(() => InvokeContentControl.SetContent(control, "test")));
            }
            TestContext.WriteLine($@"{nameof(SetContent_DoesNotThrow)} complete.");
        }
    }
}