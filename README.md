# AcExtentionLibrary
A library for working with AutoCAD managed libraries


## Project Structure ##

* **Documentation**
	* **v20.1** - version 20.1 = 2016
* **libs**
	* **acad** - AutoCAD dll's
		* **v19.0** - version 19.0 = 2013 dll's
		* **v19.1** - version 19.1 = 2014 dll's
		* **v20.0** - version 20.0 = 2015 dll's
		* **v20.1** - version 20.1 = 2016 dll's
* **src** - source files, solution and projects.
	* **Shared** - contains the shared project.
	* **v19.0** - version 19.0 = 2013 project
	* **v19.1** - version 19.1 = 2014 project
	* **v20.0** - version 20.0 = 2015 project
	* **v20.1** - version 20.1 = 2016 project

### Documentation ###
Contains a solution with a [sandcastle](https://github.com/EWSoftware/SHFB) project which uses the [Visual Studio Integration Package](https://ewsoftware.github.io/SHFB/html/b128ad2a-787e-48c7-b946-f6953080c386.htm) and the nuget package information can be found [here](https://www.nuget.org/packages/EWSoftware.SHFB). For a quick tutorial and overview see [Taming Sandcastle: A .NET Programmer's Guide to Documenting Your Code](https://www.simple-talk.com/dotnet/.net-tools/taming-sandcastle-a-.net-programmers-guide-to-documenting-your-code/) 

You can download .chm at this [Link](https://github.com/Hpadgroup/AcExtensionLibrary/blob/master/Documentation/v20.1/Help/AcExtensionLibrary%20Documentation.chm?raw=true) and after downloading right-click and unblock.

The folders under the documentation folder are basically what by default a sandcastle project will produce, and folders I added to help store content of documentation file.
###### **Samples**  ######
Samples folder *(Documentation / v20.1 / Content / Samples )* contains a solution that is used for referencing examples inside documentation.

### libs ###
Library Folder contains dll to reference for example *acmgd.dll* and this places them inside the source control so no worries of repathing, etc...

### src  ###
Source Folder contains the solutions, shared, and each year projects files used to build the assemblies.
###### **Shared**  ######
Shared folder *(src / AcExtensionLibrary / Shared )* contains the shared project. What a shared project does is just use the files to build dll's in whatever project it is referenced in. This [link](http://ambilykk.com/2015/07/27/visual-studio-2015-shared-project/) is a short good overview.



Currently working on this topic.
