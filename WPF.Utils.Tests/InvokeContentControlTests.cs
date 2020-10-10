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
            for (int i = 0; i < 10; i++)
            {
                _controls.Enqueue(new Label());
                _controls.Enqueue(new Button());
                _controls.Enqueue(new CheckBox());
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
        public void SetContent_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetContent_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ContentControl control))
            {
                foreach (var value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeContentControl.SetContent(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetContent(control, value)));
                }
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
                foreach (var value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeContentControl.AddContent(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.AddContent(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(AddContent_DoesNotThrow)} complete.");
        }
    }
}