# ReleaseDifficulty
This is a mod for Hollow Knight: Silksong that aims to restore the difficulty of the game at the time of launch.
Since then patches have reduced the difficulty of the game in various ways, such as reducing the amount of damage
a lot of enemies and hazards deal.

With this mod the original damage will be restored.

## Current Changes
- Cogs deal 2 damage again
- Sand centripedes deal 2 damage again
- The spin attack of the flying stick insects deals 2 damage again

## Installation
- Ensure BepInEx is installed for Silksong
- Place the build dependencies in the `Dependencies` directory
- Build the mod via `dotnet build`
- Place ReleaseDifficulty.dll in the plugins directory of BepInEx
- Enjoy

## Build Dependencies
- BepInEx files:
  - 0Harmony.dll
  - BepInEx.dll
- Hollow Knight: Silksong files:
  - Assembly-CSharp.dll
  - UnityEngine.dll
  - UnityEngine.CoreModule.dll
  - UnityEngine.CrashReportingModule
- System files:
  - Microsoft.CSharp.dll
  - System.dll
  - System.Core.dll
  - System.Data.dll

The BepInEx files can be found under `BepInEx/core` in your BepInEx directory.
All Silksong files are under `Hollow Knight Silksong_Data/Managed` in your Silksong installation.
System files are automatically found as long as you have a functioning .NET environment installed.

### Why aren't the dependencies distributed with the code?
I want to avoid any licensing issues, that could arise as a consequence of re-distributing
the DLL files. This is especially a problem with Assembly-CSharp.dll, which contains a lot
of the code of Silksong.

Alternatively I could have simply pointed the references to the files directly where they
are found, but this depends on the exact location of the game installation. 
This may vary between each system, so it's better to just reference files insode the project directory
and deal with having to copy over them.

## Options
|Name|Type|Default|Description|
|----|----|-------|-----------|
|EnableReleaseDifficulty|bool|true|Control whether this mod is active|
