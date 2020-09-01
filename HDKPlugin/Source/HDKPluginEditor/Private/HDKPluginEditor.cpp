// Copyright Epic Games, Inc. All Rights Reserved.

#include "HDKPluginEditor.h"

#define LOCTEXT_NAMESPACE "FHDKPluginEditorModule"

#include "HDKCommon.h"
#include <SOP/SOP_Node.h>
#include <GU/GU_Detail.h>

void FHDKPluginEditorModule::StartupModule()
{
	// This code will execute after your module is loaded into memory; the exact timing is specified in the .uplugin file per-module
	UT_BoundingBox bounds;

	bounds.setBounds(-1, -1, -1, 1, 1, 1);
	fpreal r = bounds.getRadius();

}

void FHDKPluginEditorModule::ShutdownModule()
{
	// This function may be called during shutdown to clean up your module.  For modules that support dynamic reloading,
	// we call this function before unloading the module.
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FHDKPluginEditorModule, HDKPluginEditor)