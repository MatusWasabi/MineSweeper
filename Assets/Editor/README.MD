# Build Game With CLI and Build Script

In order to achieve unity CI/CD that made by ourself, we need to be familar with Unity CLI first.
To build game that will be 2 things required to do so.

1. Build Script -> This one we need to write by our self. (This folder contain that script)
2. Command -> This one we can use ChatGPT to gen. But in case of future need.

This is the command template used

`<path-to-Unity> -quit -batchmode -projectPath "<path-to-your-project>" -buildTarget StandaloneWindows64 -executeMethod <Class.BuildMethod> -outputPath "<path-to-output-folder>"`

In my case, this is the command executed
`.\Unity -quit -batchmode -nographics -buildTarget StandaloneWindows64 -executeMethod Builder.Build -projectPath "D:\Game Development\Unity\MazeyRun"`

## Resource

- [BuildPipeline,BuildPlayer](https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html)
- [Build Game with CLI on Linux](https://docs.unity.com/embeddedlinux/en/manual/how-to-build-using-cli)

`
