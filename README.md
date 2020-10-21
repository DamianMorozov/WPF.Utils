# **WinForms.Utils** - Utils for invoking WPF conrols from async threads and tasks.

[![NuGet version](https://img.shields.io/nuget/v/WPF.Utils.svg?style=flat)](https://www.nuget.org/packages/WPF.Utils/)
[![NuGet downloads](https://img.shields.io/nuget/dt/WPF.Utils.svg)](https://www.nuget.org/packages/WPF.Utils/)

# WPF.Utils
- InvokeContentControl
- InvokeControl
- InvokeListBox
- InvokeProgressBar
- InvokeTextBox
- InvokeWebBrowser

# WPF.Utils.Tests
- EnumValues
- EnumWPF
- InvokeContentControlTests
- InvokeControlTests
- InvokeProgressBarTests
- InvokeTextBoxTests

## How to use
Example of usage:

```C#
var task = Task.Run(async () =>
{
    InvokeTextBox.Clear(textBox);
    await Task.Delay(TimeSpan.FromMilliseconds(_timeout));
});
```
