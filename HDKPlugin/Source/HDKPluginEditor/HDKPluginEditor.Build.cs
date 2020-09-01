// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.IO;
using System.Collections.Generic;
using UnrealBuildTool;

public class HDKPluginEditor : ModuleRules
{
    string HoudiniVersion = "18.0.499";

    public HDKPluginEditor(ReadOnlyTargetRules Target) : base(Target)
	{
        bUseRTTI = true;
        bEnableExceptions = true;

        // Find HFS
        string HFSPath = GetHFSPath();
        HFSPath = HFSPath.Replace("\\", "/");

        string _houdini_shared_libs = "custom/houdini/dsolib/libHOMUI.lib;custom/houdini/dsolib/libFUSE.lib;custom/houdini/dsolib/libMT.lib;custom/houdini/dsolib/libMDS.lib;custom/houdini/dsolib/libJEDI.lib;custom/houdini/dsolib/libOP3D.lib;custom/houdini/dsolib/libDM.lib;custom/houdini/dsolib/libVISF.lib;custom/houdini/dsolib/libGUI.lib;custom/houdini/dsolib/libGR.lib;custom/houdini/dsolib/libSHOP.lib;custom/houdini/dsolib/libVOP.lib;custom/houdini/dsolib/libVCC.lib;custom/houdini/dsolib/libPI.lib;custom/houdini/dsolib/libOP.lib;custom/houdini/dsolib/libLM.lib;custom/houdini/dsolib/libFS.lib;custom/houdini/dsolib/libUT.lib;custom/houdini/dsolib/libVM.lib;custom/houdini/dsolib/libSYS.lib;custom/houdini/dsolib/libtools.lib;custom/houdini/dsolib/hboost_system-mt.lib;custom/houdini/dsolib/tbb.lib;custom/houdini/dsolib/tbbmalloc.lib;custom/houdini/dsolib/libcurlwrap.lib;custom/houdini/dsolib/libPRM.lib;custom/houdini/dsolib/libCMD.lib;custom/houdini/dsolib/libCH.lib;custom/houdini/dsolib/libDEP.lib;custom/houdini/dsolib/libEXPR.lib;custom/houdini/dsolib/libHOM.lib;custom/houdini/dsolib/libPY.lib;custom/houdini/dsolib/libPXL.lib;custom/houdini/dsolib/libCL.lib;custom/houdini/dsolib/libARR.lib;custom/houdini/dsolib/libTAKE.lib;custom/houdini/dsolib/libIMG.lib;custom/houdini/dsolib/libTBF.lib;custom/houdini/dsolib/libDD.lib;custom/houdini/dsolib/libCVEX.lib;custom/houdini/dsolib/libPBR.lib;custom/houdini/dsolib/libVEX.lib;custom/houdini/dsolib/libTIL.lib;custom/houdini/dsolib/libhptex.lib;custom/houdini/dsolib/libIMG3D.lib;custom/houdini/dsolib/libGVEX.lib;custom/houdini/dsolib/libGT.lib;custom/houdini/dsolib/libGU.lib;custom/houdini/dsolib/libGSTY.lib;custom/houdini/dsolib/libSTY.lib;custom/houdini/dsolib/libGOP.lib;custom/houdini/dsolib/libGEO.lib;custom/houdini/dsolib/libGP.lib;custom/houdini/dsolib/libGD.lib;custom/houdini/dsolib/libGA.lib;custom/houdini/dsolib/libCE.lib;custom/houdini/dsolib/libTS.lib;custom/houdini/dsolib/libBV.lib;custom/houdini/dsolib/libKIN.lib;custom/houdini/dsolib/libGQ.lib;custom/houdini/dsolib/libUI.lib;custom/houdini/dsolib/libAU.lib;custom/houdini/dsolib/libRE.lib;custom/houdini/dsolib/libFONT.lib;custom/houdini/dsolib/libHARD.lib;custom/houdini/dsolib/libHAPIL.lib;custom/houdini/dsolib/libPYP.lib;custom/houdini/dsolib/libPDG.lib;custom/houdini/dsolib/libPDGT.lib;custom/houdini/dsolib/libBM.lib;custom/houdini/dsolib/libFUI.lib;custom/houdini/dsolib/libSTORUI.lib;custom/houdini/dsolib/libIPR.lib;custom/houdini/dsolib/libOPUI.lib;custom/houdini/dsolib/libPSI2.lib;custom/houdini/dsolib/libSI.lib;custom/houdini/dsolib/libBR.lib;custom/houdini/dsolib/libSS.lib;custom/houdini/dsolib/libCHOP.lib;custom/houdini/dsolib/libOH.lib;custom/houdini/dsolib/libMOT.lib;custom/houdini/dsolib/libMGR.lib;custom/houdini/dsolib/libDOPZ.lib;custom/houdini/dsolib/libSIMZ.lib;custom/houdini/dsolib/libOBJ.lib;custom/houdini/dsolib/libSOP.lib;custom/houdini/dsolib/libSOPTG.lib;custom/houdini/dsolib/libDOP.lib;custom/houdini/dsolib/libWIRE.lib;custom/houdini/dsolib/libCLO.lib;custom/houdini/dsolib/libSIM.lib;custom/houdini/dsolib/libGAS.lib;custom/houdini/dsolib/libRBD.lib;custom/houdini/dsolib/libGDT.lib;custom/houdini/dsolib/libSOPZ.lib;custom/houdini/dsolib/libFBX.lib;custom/houdini/dsolib/libDAE.lib;custom/houdini/dsolib/libCOP2.lib;custom/houdini/dsolib/libRU.lib;custom/houdini/dsolib/libTOP.lib;custom/houdini/dsolib/libROP.lib;custom/houdini/dsolib/libSOHO.lib;custom/houdini/dsolib/libLOP.lib;custom/houdini/dsolib/libHUSD.lib;custom/houdini/dsolib/libgusd.lib;custom/houdini/dsolib/libPDGD.lib;custom/houdini/dsolib/libCOPZ.lib;custom/houdini/dsolib/libCHOPZ.lib;custom/houdini/dsolib/libCHOPNET.lib;custom/houdini/dsolib/libCOPNET.lib;custom/houdini/dsolib/libVOPNET.lib;custom/houdini/dsolib/libTOPNET.lib;custom/houdini/dsolib/libGABC.lib;custom/houdini/dsolib/libIMGUI.lib;custom/houdini/dsolib/libGLTF.lib;custom/houdini/dsolib/libSHLFUI.lib;custom/houdini/dsolib/libSHLF.lib;custom/houdini/dsolib/libVIS.lib;custom/houdini/dsolib/libCV.lib;custom/houdini/dsolib/libSTOR.lib;custom/houdini/dsolib/libMH.lib;custom/houdini/dsolib/libMCS.lib;custom/houdini/dsolib/libMWS.lib;custom/houdini/dsolib/libMPI.lib;custom/houdini/dsolib/libMSS.lib;custom/houdini/dsolib/libMLS.lib;custom/houdini/dsolib/libIMS.lib;custom/houdini/dsolib/libIMP.lib;custom/houdini/dsolib/libIMH.lib;custom/houdini/dsolib/libIM.lib;custom/houdini/dsolib/libMATUI.lib;custom/houdini/dsolib/libJIVE.lib;custom/houdini/dsolib/libCHUI.lib;custom/houdini/dsolib/libTHOR.lib;custom/houdini/dsolib/libMIDI.lib;custom/houdini/dsolib/libDTUI.lib;custom/houdini/dsolib/libHOMF.lib;custom/houdini/dsolib/libRAY.lib;custom/houdini/dsolib/libVPRM.lib;custom/houdini/dsolib/libVGEO.lib;custom/houdini/dsolib/libBRAY.lib";
        string _houdini_shared_lib_targets = "HOMUI;FUSE;MT;MDS;JEDI;OP3D;DM;VISF;GUI;GR;SHOP;VOP;VCC;PI;OP;LM;FS;UT;VM;SYS;tools;hboost_system;tbb;tbbmalloc;curlwrap;PRM;CMD;CH;DEP;EXPR;HOM;PY;PXL;CL;ARR;TAKE;IMG;TBF;DD;CVEX;PBR;VEX;TIL;hptex;IMG3D;GVEX;GT;GU;GSTY;STY;GOP;GEO;GP;GD;GA;CE;TS;BV;KIN;GQ;UI;AU;RE;FONT;HARD;HAPIL;PYP;PDG;PDGT;BM;FUI;STORUI;IPR;OPUI;PSI2;SI;BR;SS;CHOP;OH;MOT;MGR;DOPZ;SIMZ;OBJ;SOP;SOPTG;DOP;WIRE;CLO;SIM;GAS;RBD;GDT;SOPZ;FBX;DAE;COP2;RU;TOP;ROP;SOHO;LOP;HUSD;gusd;PDGD;COPZ;CHOPZ;CHOPNET;COPNET;VOPNET;TOPNET;GABC;IMGUI;GLTF;SHLFUI;SHLF;VIS;CV;STOR;MH;MCS;MWS;MPI;MSS;MLS;IMS;IMP;IMH;IM;MATUI;JIVE;CHUI;THOR;MIDI;DTUI;HOMF;RAY;VPRM;VGEO;BRAY";

        char[] charSeparators = new char[] { ';' };
        string[] houdiniSharedLibs = _houdini_shared_libs.Split(charSeparators);
        string[] houdiniSharedLibTargets = _houdini_shared_lib_targets.Split(charSeparators);

        string HDKIncludePath = HFSPath + "/toolkit/include";
        if (!Directory.Exists(HDKIncludePath))
        {
            System.Console.WriteLine(string.Format("Couldnt find the Houdini HDK include folder!"));
            HDKIncludePath = "";
        }

        if (HDKIncludePath != "")
            PublicIncludePaths.Add(HDKIncludePath);

        foreach(string houdiniSharedLibTarget in houdiniSharedLibTargets)
        {
            var dllName = "lib" + houdiniSharedLibTarget + ".dll";
            var dllPath = Path.Combine(HFSPath + "/bin", dllName);
            //PublicDelayLoadDLLs.Add(dllName);
            RuntimeDependencies.Add(dllPath);
        }

        foreach (string houdiniSharedLib in houdiniSharedLibs)
        {
            var libPath = Path.Combine(HFSPath, houdiniSharedLib);
            PublicAdditionalLibraries.Add(libPath);
        }

        string Defines = "AMD64;SIZEOF_FPREAL_IS_4;SIZEOF_VOID_P=8;FBX_ENABLED=1;OPENCL_ENABLED=1;OPENVDB_ENABLED=1;SESI_LITTLE_ENDIAN;UT_ASSERT_LEVEL=2;I386;WIN32;SWAP_BITFIELDS;_WIN32_WINNT=0x0600;NOMINMAX;STRICT;WIN32_LEAN_AND_MEAN;_USE_MATH_DEFINES;_CRT_SECURE_NO_DEPRECATE;_CRT_NONSTDC_NO_DEPRECATE;_SCL_SECURE_NO_WARNINGS;HBOOST_ALL_NO_LIB;EIGEN_MALLOC_ALREADY_ALIGNED=0";

        string[] defineList = Defines.Split(charSeparators);
        foreach (string ecahDefine in defineList)
        {
            PublicDefinitions.Add(ecahDefine);
        }

        // PublicDefinitions.Add;

        // PublicAdditionalLibraries;

        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);
	}

    private string GetHFSPath()
    {
        bool bIsRelease = true;
        string HFSPath = "C:/cygwin/home/prisms/builder-new/Nightly18.0CMake/dev/hfs";
        string RegistryPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Side Effects Software";

        if (!bIsRelease)
        {
            // Only use the preset build folder
            System.Console.WriteLine("Using stamped HFSPath:" + HFSPath);
            return HFSPath;
        }

        // Look for the Houdini install folder for this platform
        PlatformID buildPlatformId = Environment.OSVersion.Platform;
        if (buildPlatformId == PlatformID.Win32NT)
        {
            // Look for the HEngine install path in the registry
            string HEngineRegistry = RegistryPath + string.Format(@"\Houdini Engine {0}", HoudiniVersion);
            string HPath = Microsoft.Win32.Registry.GetValue(HEngineRegistry, "InstallPath", null) as string;
            if (HPath != null)
            {
                if (Directory.Exists(HPath))
                    return HPath;
            }

            // If we couldn't find the Houdini Engine registry path, try the default one
            string DefaultHPath = "C:/Program Files/Side Effects Software/Houdini Engine " + HoudiniVersion;
            if (DefaultHPath != HPath)
            {
                if (Directory.Exists(DefaultHPath))
                    return DefaultHPath;
            }

            // Look for the Houdini registry install path for the version the plug-in was compiled for
            string HoudiniRegistry = RegistryPath + string.Format(@"\Houdini {0}", HoudiniVersion);
            HPath = Microsoft.Win32.Registry.GetValue(HoudiniRegistry, "InstallPath", null) as string;
            if (HPath != null)
            {
                if (Directory.Exists(HPath))
                    return HPath;
            }

            // If we couldn't find the Houdini registry path, try the default one
            DefaultHPath = "C:/Program Files/Side Effects Software/Houdini " + HoudiniVersion;
            if (DefaultHPath != HPath)
            {
                if (Directory.Exists(DefaultHPath))
                    return DefaultHPath;
            }

            // See if the preset build HFS exists
            if (Directory.Exists(HFSPath))
                return HFSPath;

            // We couldn't find the exact version the plug-in was built for, we can still try with the active version in the registry
            string ActiveHEngine = Microsoft.Win32.Registry.GetValue(RegistryPath, "ActiveEngineVersion", null) as string;
            if (ActiveHEngine != null)
            {
                // See if the latest active HEngine version has the proper major/minor version
                if (ActiveHEngine.Substring(0, 4) == HoudiniVersion.Substring(0, 4))
                {
                    HEngineRegistry = RegistryPath + string.Format(@"\Houdini Engine {0}", ActiveHEngine);
                    HPath = Microsoft.Win32.Registry.GetValue(HEngineRegistry, "InstallPath", null) as string;
                    if (HPath != null)
                    {
                        if (Directory.Exists(HPath))
                            return HPath;
                    }
                }
            }

            // Active HEngine version didn't match, so try with the active Houdini version
            string ActiveHoudini = Microsoft.Win32.Registry.GetValue(RegistryPath, "ActiveVersion", null) as string;
            if (ActiveHoudini != null)
            {
                // See if the latest active Houdini version has the proper major/minor version
                if (ActiveHoudini.Substring(0, 4) == HoudiniVersion.Substring(0, 4))
                {
                    HoudiniRegistry = RegistryPath + string.Format(@"\Houdini {0}", ActiveHoudini);
                    HPath = Microsoft.Win32.Registry.GetValue(HoudiniRegistry, "InstallPath", null) as string;
                    if (HPath != null)
                    {
                        if (Directory.Exists(HPath))
                            return HPath;
                    }
                }
            }
        }
        else if (buildPlatformId == PlatformID.MacOSX ||
            (buildPlatformId == PlatformID.Unix && File.Exists("/System/Library/CoreServices/SystemVersion.plist")))
        {
            // Check for Houdini installation.
            string HPath = "/Applications/Houdini/Houdini" + HoudiniVersion + "/Frameworks/Houdini.framework/Versions/Current/Resources";
            if (Directory.Exists(HPath))
                return HPath;

            HPath = "/Users/Shared/Houdini/HoudiniIndieSteam/Frameworks/Houdini.framework/Versions/Current/Resources";
            if (Directory.Exists(HPath))
                return HPath;

            if (Directory.Exists(HFSPath))
                return HFSPath;
        }
        else if (buildPlatformId == PlatformID.Unix)
        {
            HFSPath = System.Environment.GetEnvironmentVariable("HFS");
            if (Directory.Exists(HFSPath))
            {
                System.Console.WriteLine("Unix using $HFS: " + HFSPath);
                return HFSPath;
            }
        }
        else
        {
            System.Console.WriteLine(string.Format("Building on an unknown environment!"));
        }

        string Err = string.Format("Houdini Engine : Please install Houdini or Houdini Engine {0}", HoudiniVersion);
        System.Console.WriteLine(Err);

        return "";
    }
}
