/*
    Network Next SDK. Copyright © 2017 - 2021 Network Next, Inc.

    Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following 
    conditions are met:

    1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

    2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
       and the following disclaimer in the documentation and/or other materials provided with the distribution.

    3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote 
       products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
    INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
    IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
    CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
    OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
    NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using UnrealBuildTool;

public class NetworkNext : ModuleRules
{
    public NetworkNext(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDefinitions.Add("NEXT_UNREAL_ENGINE=1");

        PublicDependencyModuleNames.AddRange(
            new string[] {
                "OnlineSubsystemUtils",
            }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "Projects",
                "CoreUObject",
                "Engine",
                "Sockets",
                "OnlineSubsystem",
                "PacketHandler",
            }
        );

        bEnableUndefinedIdentifierWarnings = false;
		
        if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicFrameworks.Add("SystemConfiguration");
        } 
        else if (Target.Platform.ToString() == "PS4")
        {
            string SDKDir = System.Environment.GetEnvironmentVariable("SCE_ORBIS_SDK_DIR");
            string LibDir = System.IO.Path.Combine(SDKDir, "target", "lib");
            PublicAdditionalLibraries.Add(System.IO.Path.Combine(LibDir, "libSceSecure.a"));
        }
    }
}
