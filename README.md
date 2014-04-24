ScreenShot
=============

Screen printing utility.

**Use**

On launch, sits in the notification area and monitors for a defined key combination (default is `Shift + Alt + S`) or (optionally) a right click on the application's icon.

To configure the utility, left click on the icon in the notification area.


**Er, why?**

When working remotely on corporate networks this gets around the problem of taking screenshots and using them on the remote site. This can be a problem where clipboard sharing has been locked down (such as on remote desktop connections), as the screenshots are normally taken and saved into the local clipboard, not the one in the remote session. It can then take couple of emails, possibly from a personal account, to get that screenshot back to be available for use within the remote network.

Instead, using this app, the screenshot is saved to the remote clipboard directly, and can be pasted directly into emails/documents and so on. 



**Configuration**

To configure the hotkey, or to toggle the right-click functionality, left-click on the icon in the notification area.


*Choosing a hotkey*

The default hot key is `Shift + Alt + S`, however this may not always work, depending on what other software has set as its own hotkeys/shortcut keys.

It may be necessary to try a few combinations to see what works for you, especially the `Win` key (which probably won't work remotely, but is included for completeness).

In general, use combinations with at least one of `Shift`, `Alt`, or `Ctrl` as this will give a better chance of avoiding conflict with other software.

*Right Click*

There is also the optional use of right-click on the icon in the notification area to take a screenshot. This can be disabled in the settings if required.


**Build**

*Self-build*

The solution is built in Visual Studio 2013 on .Net Framework 4.0. Is uses only .Net Framework and Windows API functionality, and has no third-party dependencies. Therefore it should be easily built using any version of VS2010,VS2012 or VS2013.

To redistribute just take the contents of the ScreenShot.exe file from the bin/Release folder, and copy to the target machine. There should be no other requirement to run, other than the presence of the relevant .Net framework version, and the required privileges.


*Download package*

The latest built binaries are available from [here](https://github.com/ja2/ScreenShot/releases/latest).


**Security**

*Privileges*

ScreenShot requires a number of different security privileges to work:

1. Access to the Windows notification area.
2. Registry access (for the Launch On Login functionality).
3. Read-write file system access to the folder that the executable is run from, to save/read settings.
4. Access to RegisterHotKey and UnregisterHotKey windows API commands to hook windows key combinations

*Trust*

A built binary is provided for convience. While limited precautions are taken to keep this free from malware, no certification is given that this is the case.

If you do not trust the built binary, then the source code is provided. This can be audited and manually built to give a better guarantee that the binary you use is free of malware. It is for this reason that ScreenShot makes no use of any code library other than the .Net Framework, and the Windows system APIs. No third party compiled code is used.



**FAQ/Troubleshooting**

Below are some guides on common error messages from ScreenShot. If you don't think that these cover a problem you're having, please raise an issue here in GitHub.


*Couldn’t register the hot key.*

Some combinations of hotkey are not possible, either because they are already registered by some other application, or because they are illegal for some reason.

See the guide on "Choosing a hotkey" for more on different combinations of keys

If no combination of hotkeys can be registered, then there is still the fallback feature available to right-click on the application icon on the system tray to take a ScreenShot.


*Could not load configuration from '<A path>'. Error was '<An error>'*
*Could not save configuration to '<A path>'. Error was '<An error>'*

ScreenShot wasn't able to save its settings to file. The settings are saved in a ScreenShotSettings.config file in location that ScreenShot.exe is running from. If you have this problem try moving the ScreenShot.exe to a different location.

The application should still work if this is the case, but it won't be possible to use anything other than the default settings for the application

*Could not load configuration from registry'. Error was '<An error>'*
*Could not save configuration to registry. Error was '<An error>'*

ScreenShot wasn't able to read/update the registry to enable/disable the "Launch On Login" feature. Where this occurs it is likely to be due to the permission level of the user running ScreenShot.

ScreenShot should still work if this is the case, but it won't be possible to use anything other than the default settings for ScreenShot.


**Disclaimer**

Use of ScreenShot is strictly at your own risk. ScreenShot is not provided with any warranties of any sort to the maximum extent allowable by law. 

ScreenShot should not be used without the expressed permission of the administrator of your system.

Do not use ScreenShot unless you are fully satisfied that it does not pose a risk of any sort to the systems where it is to be used.



