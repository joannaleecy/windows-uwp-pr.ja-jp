---
title: Creating a basic Windows Runtime component in C++ and calling it from JavaScript or C#
description: This walkthrough shows how to create a basic Windows Runtime Component DLL that's callable from JavaScript, C#, or Visual Basic.
ms.assetid: 764CD9C6-3565-4DFF-88D7-D92185C7E452
---

# Walkthrough: Creating a basic Windows Runtime component in C++ and calling it from JavaScript or C#


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.\]

This walkthrough shows how to create a basic Windows Runtime Component DLL that's callable from JavaScript, C#, or Visual Basic. Before you begin this walkthrough, make sure that you understand concepts such as the Abstract Binary Interface (ABI), ref classes, and the Visual C++ Component Extensions that make working with ref classes easier. For more information, see [Creating Windows Runtime Components in C++](creating-windows-runtime-components-in-cpp.md) and [Visual C++ Language Reference (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx).

## Creating the C++ component DLL


In this example, we create the component project first, but you could create the JavaScript project first. The order doesn’t matter.

Notice that the main class of the component contains examples of property and method definitions, and an event declaration. These are provided just to show you how it's done. They are not required, and in this example, we'll replace all of the generated code with our own code.

## **To create the C++ component project**

1.  On the Visual Studio menu bar, choose **File, New, Project**.
2.  In the **New Project** dialog box, in the left pane, expand **Visual C++** and then select the node for Universal Windows apps.
3.  In the center pane, select **Windows Runtime Component** and then name the project WinRT\_CPP.
4.  Choose the **OK** button.

## **To add an activatable class to the component**

1.  An activatable class is one that client code can create by using a **new** expression (**New** in Visual Basic, or **ref new** in C++). In your component, you declare it as **public ref class sealed**. In fact, the Class1.h and .cpp files already have a ref class. You can change the name, but in this example we’ll use the default name—Class1. You can define additional ref classes or regular classes in your component if they are required. For more information about ref classes, see [Type System (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx).

2.  Add these \#include directives to Class1.h:

    ```cpp
             private void PrimesUnOrderedButton_Click_1(object sender, RoutedEventArgs e)
            {
                var nativeObject = new WinRT_CPP.Class1();

                StringBuilder sb = new StringBuilder();
                sb.Append("Primes found (unordered): ");
                PrimesUnOrderedResult.Text = sb.ToString();

                // primeFoundEvent is a user-defined event in nativeObject
                // It passes the results back to this thread as they are produced
                // and the event handler that we define here immediately displays them.
                nativeObject.primeFoundEvent += (n) =>
                {
                    sb.Append(n.ToString()).Append(" ");
                    PrimesUnOrderedResult.Text = sb.ToString();
                };

                // Call the async method.
                var asyncResult = nativeObject.GetPrimesUnordered(2, 100000);

                // Provide a handler for the Progress event that the asyncResult
                // object fires at regular intervals. This handler updates the progress bar.
                asyncResult.Progress += (asyncInfo, progress) =>
                    {
                        PrimesUnOrderedProgress.Value = progress;
                    };
            }

            private void Clear_Button_Click(object sender, RoutedEventArgs e)
            {
                PrimesOrderedProgress.Value = 0;
                PrimesUnOrderedProgress.Value = 0;
                PrimesUnOrderedResult.Text = "";
                PrimesOrderedResult.Text = "";
                Result1.Text = "";
            }
    ```

## Running the app


Select either the C# project or JavaScript project as the startup project by opening the shortcut menu for the project node in Solution Explorer and choosing **Set As Startup Project**. Then press F5 to run with debugging, or Ctrl+F5 to run without debugging.

## Inspecting your component in Object Browser (optional)


In Object Browser, you can inspect all Windows Runtime types that are defined in .winmd files. This includes the types in the Platform namespace and the default namespace. However, because the types in the Platform::Collections namespace are defined in the header file collections.h, not in a winmd file, they don’t appear in Object Browser.

## **To inspect a component**

1.  On the menu bar, choose **View, Object Browser** (Ctrl+Alt+J).
2.  In the left pane of the Object Browser, expand the WinRT\_CPP node to show the types and methods that are defined on your component.

## Debugging tips


For a better debugging experience, download the debugging symbols from the public Microsoft symbol servers:

## **To download debugging symbols**

1.  On the menu bar, choose **Tools, Options**.
2.  In the **Options** dialog box, expand **Debugging** and select **Symbols**.
3.  Select **Microsoft Symbol Servers** and the choose the **OK** button.

It might take some time to download the symbols the first time. For faster performance the next time you press F5, specify a local directory in which to cache the symbols.

When you debug a JavaScript solution that has a component DLL, you can set the debugger to enable either stepping through script or stepping through native code in the component, but not both at the same time. To change the setting, open the shortcut menu for the JavaScript project node in Solution Explorer and choose **Properties, Debugging, Debugger Type**.

Be sure to select appropriate capabilities in the package designer. You can open the package designer by opening the Package.appxmanifest file. For example, if you are attempting to programmatically access files in the Pictures folder, be sure to select the **Pictures Library** check box in the **Capabilities** pane of the package designer.

If your JavaScript code doesn't recognize the public properties or methods in the component, make sure that in JavaScript you are using camel casing. For example, the `ComputeResult` C++ method must be referenced as `computeResult` in JavaScript.

If you remove a C++ Windows Runtime Component project from a solution, you must also manually remove the project reference from the JavaScript project. Failure to do so prevents subsequent debug or build operations. If necessary, you can then add an assembly reference to the DLL.

## Related topics

* [Creating Windows Runtime Components in C++](creating-windows-runtime-components-in-cpp.md)



<!--HONumber=Mar16_HO1-->


