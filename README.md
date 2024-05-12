# GOI Background Image Mod
This mod replaces the background of the Getting Over It map with an image of your choice

## Installation and Usage
This mod is built in the BepInEx framework, that means you'll need to [install BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html).\
Once you've done that, navigate to the [releases](https://github.com/BarackOBusiness/GOIBackgroundImage/releases) section of this repository and download the latest version of the mod.\
Choose the version that corresponds to the BepInEx version you installed earlier.\
Place the download in the `BepInEx/plugins` folder inside of your game's root folder, and you're done with installation.

### Settings
By default this mod uses the image located at `Getting Over It/Backgrounds/Image.png`, if there is none, the background will show up as pure white.\
You can change what image the mod loads by either placing your own image in place of that `Image.png`, or by modifying the path the mod searches for the image in the config file.\
This can be found in the `BepInEx/config/goi.ext.imagebackground.cfg` file and modified with a text editor. 

## Compilation
Make sure you have a dotnet sdk installed, version 7.x is verified to work here.\
Clone the repository, and create the directory `lib/netstandard2.0` within the project root, copy GOIs Assembly-CSharp.dll and Rewired_Core.dll into it.\
Use `dotnet build` to compile the project with the -c flag set to B5 or B6 depending on whether you want to build the mod for BepInEx 5.x or 6.0.0-pre.1 respectively.\
Then the dll can then be found in the `Release/ImageBackground.BepInEx*/netstandard2.0` folder replacing * with the version you chose.

