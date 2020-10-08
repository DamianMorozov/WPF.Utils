using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeContentControlTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ContentControl> _controls;

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
            _controls = new ConcurrentQueue<ContentControl>();
            _controls.Enqueue(new Label());
            _controls.Enqueue(new Button());
            _controls.Enqueue(new CheckBox());
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
        public void SetContent_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetContent_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ContentControl control))
            {
                Assert.DoesNotThrow(() => InvokeContentControl.SetContent(control, "test 1"));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetContent(control, "test 2")));
            }
            TestContext.WriteLine($@"{nameof(SetContent_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddContent_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(AddContent_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ContentControl control))
            {
                Assert.DoesNotThrow(() => InvokeContentControl.AddContent(control, "test 1"));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.AddContent(control, "test 2")));
            }
            TestContext.WriteLine($@"{nameof(AddContent_DoesNotThrow)} complete.");
        }
    }
}