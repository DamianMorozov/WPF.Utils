using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Controls;

namespace WPF.Utils.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeProgressBarTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ProgressBar> _controls;

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
            _controls = new ConcurrentQueue<ProgressBar>();
            for (var i = 0; i < 10; i++)
                _controls.Enqueue(new ProgressBar());
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
        public void SetMaximum_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetMaximum_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (var value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMaximum(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMaximum(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetMaximum_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetMinimum_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetMinimum_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (var value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMinimum(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMinimum(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetMinimum_DoesNotThrow)} complete.");
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetValue_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetValue_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (var value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetValue(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetValue(control, value)));
                }
            }
            TestContext.WriteLine($@"{nameof(SetValue_DoesNotThrow)} complete.");
        }
    }
}